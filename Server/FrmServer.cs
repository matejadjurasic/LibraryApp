using Server.GuiControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            InitializeComponent();
            btnStart.Click += ServerGuiController.Instance.StartServer;
            btnStop.Click += ServerGuiController.Instance.StopServer;
            this.FormClosed += ServerGuiController.Instance.FormClosed;
        }
    }
}
