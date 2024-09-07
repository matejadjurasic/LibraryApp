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
    public partial class FrmUserMain : Form
    {
        public FrmUserMain()
        {
            InitializeComponent();
            btnLogout.Click += UserMainGuiController.Instance.Logout;
            txtSearchTerm.TextChanged += UserMainGuiController.Instance.Search;
            btnDetails.Click += UserMainGuiController.Instance.ViewBook;
            this.FormClosed += UserMainGuiController.Instance.FormClosed;
        }
    }
}
