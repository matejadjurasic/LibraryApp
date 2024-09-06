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
    public class UserGuiController
    {
        private static UserGuiController instance;
        public static UserGuiController Instance
        {
            get
            {
                if (instance == null) instance = new UserGuiController();
                return instance;
            }
        }
        private FrmUser frmUser;
        private Korisnik user;

        internal void ShowFrmUser(Korisnik user)
        {
            this.user = user;
            frmUser = new FrmUser();
            frmUser.AutoSize = false;
            frmUser.TxtName.Text = user.Ime;
            frmUser.TxtUsername.Text = user.KorisnickoIme;
            frmUser.TxtSurname.Text = user.Prezime;
            frmUser.TxtPassword.Text = user.Sifra;
            frmUser.TxtPassword.PasswordChar = '*';
            frmUser.ShowDialog();
        }

        internal void Checked(object sender, EventArgs e)
        {
            if(frmUser.CheckUpdate.Checked)
            {
                frmUser.TxtName.ReadOnly = false;
                frmUser.TxtSurname.ReadOnly = false;
                frmUser.TxtUsername.ReadOnly = false;
                frmUser.TxtPassword.ReadOnly = false;
            }
            else
            {
                frmUser.TxtName.ReadOnly = true;
                frmUser.TxtSurname.ReadOnly = true;
                frmUser.TxtUsername.ReadOnly = true;
                frmUser.TxtPassword.ReadOnly = true;
            }
        }

        internal void UpdateUser(object sender, EventArgs e)
        {
            Korisnik updatedUser = new Korisnik
            {
                KorisnikId = user.KorisnikId,
                Ime = frmUser.TxtName.Text,
                Prezime = frmUser.TxtSurname.Text,
                KorisnickoIme = frmUser.TxtUsername.Text,
                Sifra = frmUser.TxtPassword.Text
            };

            Response r = Communication.Instance.UpdateUser(updatedUser);
            if (r.Exception == null && (bool)r.Result == true)
            {
                MessageBox.Show("Korisnik uspesno azuriran", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainGuiController.Instance.RefreshUserTable();
                frmUser.Dispose();
            }
            else
            {
                MessageBox.Show("Greska pri azuriranju", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
