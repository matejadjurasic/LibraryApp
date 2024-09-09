using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Response r = Communication.Instance.GetUser(user);
            if (r.Exception == null && r.Result != null)
            {
                this.user = (Korisnik)r.Result;
            }
            frmUser = new FrmUser();
            frmUser.AutoSize = false;
            frmUser.TxtName.Text = user.Ime;
            frmUser.TxtUsername.Text = user.KorisnickoIme;
            frmUser.TxtSurname.Text = user.Prezime;
            frmUser.TxtPassword.Text = user.Sifra;
            MessageBox.Show("Sistem je ucitao podatke o izabranom korisniku", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmUser.ShowDialog();
        }


        internal void UpdateUser(object sender, EventArgs e)
        {
            if (frmUser.TxtName.Text.Length < 1 || frmUser.TxtSurname.Text.Length < 1 || frmUser.TxtPassword.Text.Length < 1 || frmUser.TxtUsername.Text.Length < 1)
            {
                MessageBox.Show("Sva polja moraju imati barem jedno slovo", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(frmUser.TxtName.Text, @"^[A-Za-z]+$") || !Regex.IsMatch(frmUser.TxtSurname.Text, @"^[A-Za-z]+$"))
            {
                MessageBox.Show("Ime i prezime moraju imati samo slova", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                MessageBox.Show("Sistem je zapamtio nove podatke o korisniku", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainGuiController.Instance.RefreshUserTable();
                frmUser.Dispose();
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti korisnika", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
