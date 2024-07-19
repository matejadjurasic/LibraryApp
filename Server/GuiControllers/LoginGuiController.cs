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
        private Bibliotekar bibliotekar;
        
        public LoginGuiController()
        {

        }

        internal void ShowFrmLogin()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin = new FrmLogin();
            frmLogin.AutoSize = true;
            Application.Run(frmLogin);
        }

        public void Login(object sender, EventArgs e)
        {
            Bibliotekar b = new Bibliotekar
            {
                KorisnickoIme = frmLogin.TxtUsername.Text,
                Sifra = frmLogin.TxtPassword.Text,
            };

            bibliotekar = Controller.Instance.LoginB(b);


            if (bibliotekar != null)
            {
                frmLogin.Visible = false;
                MainGuiController.Instance.ShowFrmMain(bibliotekar);

            }
            else
            {
                MessageBox.Show("Error logging in");
            }
        }
    }
}
