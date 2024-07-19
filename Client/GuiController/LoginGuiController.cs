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
            Communication.Instance.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin = new FrmLogin();
            frmLogin.AutoSize = true;
            Application.Run(frmLogin);
        }

        public void Login(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik
            {
                KorisnickoIme = frmLogin.TxtUsername.Text,
                Sifra = frmLogin.TxtPassword.Text
            };
            Response r = Communication.Instance.Login(k);
            if(r.Exception == null && r.Result != null)
            {
                frmLogin.Visible = false;
                MainGuiController.Instance.ShowFrmMain((Korisnik)r.Result);

            }
            else
            {
                MessageBox.Show("Error logging in");
            }
        }
    }
}
