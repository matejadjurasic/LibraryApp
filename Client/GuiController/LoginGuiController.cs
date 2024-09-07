using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class LoginGuiController
    {
        private static LoginGuiController instance;
        public static LoginGuiController Instance 
        { 
            get 
            { 
                if (instance == null) instance = new LoginGuiController();
                return instance; 
            } 
        }

        private FrmLogin frmLogin;
        public LoginGuiController()
        {

        }

        internal void ShowFrmLogin()
        {
            try
            {
                Communication.Instance.Connect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmLogin = new FrmLogin();
                frmLogin.AutoSize = true;
                Application.Run(frmLogin);
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Nemoguce povezivanje sa serverom", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void Login(object sender, EventArgs e)
        {
            if (frmLogin.CheckAdmin.Checked)
            {
                Bibliotekar b = new Bibliotekar
                {
                    KorisnickoIme = frmLogin.TxtUsername.Text,
                    Sifra = frmLogin.TxtPassword.Text
                };
                Response r = Communication.Instance.LoginB(b);
                if (r.Exception == null && r.Result != null)
                {
                    MessageBox.Show("Prijavljeni ste", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLogin.Visible = false;
                    MainGuiController.Instance.ShowFrmMain((Bibliotekar)r.Result);

                }
                else
                {
                    MessageBox.Show("Neuspesna prijava, uneti su nepostojeci parametri", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Korisnik k = new Korisnik
                {
                    KorisnickoIme = frmLogin.TxtUsername.Text,
                    Sifra = frmLogin.TxtPassword.Text
                };
                Response r = Communication.Instance.Login(k);
                if (r.Exception == null && r.Result != null)
                {
                    MessageBox.Show("Prijavljeni ste", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLogin.Visible = false;
                    UserMainGuiController.Instance.ShowFrmMain((Korisnik)r.Result);

                }
                else
                {
                    MessageBox.Show("Neuspesna prijava, uneti su nepostojeci parametri", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        internal void SetVisible()
        {
            frmLogin.Visible=true;
        }

        internal void FormClosed(object sender, FormClosedEventArgs e)
        {
            Communication.Instance.Disconnect();
            Application.Exit();
        }
    }
}
