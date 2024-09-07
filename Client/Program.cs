﻿using Client.GuiController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.ApplicationExit += (o, e) => { Communication.Instance.Disconnect(); };
            LoginGuiController.Instance.ShowFrmLogin();
        }
    }
}
