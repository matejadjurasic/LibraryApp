using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.GuiControllers
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

            if (Controller.Instance.SaveUser(korisnik))
            {
                MessageBox.Show("Korisnik dodat");
                MainGuiController.Instance.RefreshUserTable();
                frmCreateUser?.Dispose();
            }
            else
            {
                MessageBox.Show("Dodavanje korisnika nije uspelo");
            }
        }
    }
}
