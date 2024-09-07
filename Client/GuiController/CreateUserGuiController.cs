using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class CreateUserGuiController
    {
        private static CreateUserGuiController instance;
        public static CreateUserGuiController Instance
        {
            get
            {
                if (instance == null) instance = new CreateUserGuiController();
                return instance;
            }
        }
        private FrmCreateUser frmCreateUser;

        internal void ShowFrmCreateUser()
        {
            frmCreateUser = new FrmCreateUser();
            frmCreateUser.AutoSize = true;
            frmCreateUser.ShowDialog();
        }

        public void AddUser(object sender, EventArgs e)
        {
            Korisnik korisnik = new Korisnik 
            {
                Ime = frmCreateUser.TxtName.Text,
                Prezime = frmCreateUser.TxtSurname.Text,
                KorisnickoIme = frmCreateUser.TxtUsername.Text,
                Sifra = frmCreateUser.TxtPassword.Text
            };

            Response r = Communication.Instance.AddUser(korisnik);
            if (r.Exception == null && (bool)r.Result == true)
            {
                MessageBox.Show("Sistem je zapamtio korisnika", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainGuiController.Instance.RefreshUserTable();
                frmCreateUser.Dispose();
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti korisnika", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
