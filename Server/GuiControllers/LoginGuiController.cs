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

        public Server Server { get => server; set => server = value; }
        public bool ServerStatus { get => serverStatus; set => serverStatus = value; }

        private FrmLogin frmLogin;
        private Bibliotekar bibliotekar;
        private Server server;
        private bool serverStatus = false;
        
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

        public void SetVisible()
        {
            frmLogin.Visible = true;
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
                MainGuiController.Instance.ShowFrmMain(bibliotekar, serverStatus);

            }
            else
            {
                MessageBox.Show("Neuspesna prijava, uneti su nepostojeci parametri!");
            }
        }

        internal void FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serverStatus)
            {
                server.Stop();
            }
            Application.Exit();
        }
    }
}
