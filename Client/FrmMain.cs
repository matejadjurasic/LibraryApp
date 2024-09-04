using Client.GuiController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            btnLogout.Click += MainGuiController.Instance.Logout;
            txtSearchTerm.TextChanged += MainGuiController.Instance.Search;
            this.FormClosed += MainGuiController.Instance.FormClosed;
        }
    }
}
