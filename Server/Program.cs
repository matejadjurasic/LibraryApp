using Server.GuiControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServerGuiController.Instance.ShowFrmServer();
            //LoginGuiController.Instance.ShowFrmLogin();
        }
    }
}
