using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.GuiControllers
{
    public class ServerGuiController
    {
        private static ServerGuiController instance;
        public static ServerGuiController Instance
        {
            get
            {
                if (instance == null) instance = new ServerGuiController();
                return instance;
            }
        }
        private FrmServer frmServer;
        private Server server;

        internal void ShowFrmServer()
        {
            frmServer = new FrmServer();
            frmServer.BtnStop.Enabled = false;
            frmServer.LblStatus.Text = "Server nije pokrenut";
            frmServer.LstUsers.DataSource = Controller.Instance.LoggedInUsers;
            frmServer.LstLibrarians.DataSource = Controller.Instance.LoggedInAdmins;
            frmServer.AutoSize = false;
            frmServer.ShowDialog();
        }

        internal void StartServer(object sender, EventArgs e)
        {
            server = new Server();
            frmServer.BtnStart.Enabled = false;
            frmServer.BtnStop.Enabled = true;
            frmServer.LblStatus.Text = "Server je pokrenut";
            server.Start();
        }

        internal void StopServer(object sender, EventArgs e)
        {
            frmServer.BtnStart.Enabled = true;
            frmServer.BtnStop.Enabled = false;
            frmServer.LblStatus.Text = "Server nije pokrenut";
            server.Stop();
        }

        public void RefreshUserTable()
        {
            if (frmServer.InvokeRequired)
            {
                frmServer.Invoke(new  MethodInvoker(RefreshUserTable));
                return;
            }
            frmServer.LstUsers.DataSource = null;
            frmServer.LstUsers.DataSource = Controller.Instance.LoggedInUsers;
        }

        public void RefreshLibrarianTable()
        {
            if (frmServer.InvokeRequired)
            {
                frmServer.Invoke(new MethodInvoker(RefreshLibrarianTable));
                return;
            }
            frmServer.LstLibrarians.DataSource = null;
            frmServer.LstLibrarians.DataSource = Controller.Instance.LoggedInAdmins;
        }

        internal void FormClosed(object sender, FormClosedEventArgs e)
        {
            if(frmServer.BtnStop.Enabled)
            {
                server.Stop();
            }
            Application.Exit();
        }
    }
}
