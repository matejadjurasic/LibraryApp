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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            btnAddNewUser.Click += MainGuiController.Instance.MakeNewUser;
            btnAddWriter.Click += MainGuiController.Instance.MakeNewWriter;
            btnAddBook.Click += MainGuiController.Instance.MakeNewBook;
            btnDeleteUser.Click += MainGuiController.Instance.DeleteUser;
            btnAddConfirmation.Click += MainGuiController.Instance.AddConfirmation;
            btnViewUser.Click += MainGuiController.Instance.ViewUser;
            btnViewBook.Click += MainGuiController.Instance.ViewBook;
            txtSearchTerm.TextChanged += MainGuiController.Instance.Search;
            txtSearchUsers.TextChanged += MainGuiController.Instance.SearchUsers;
            btnStart.Click += MainGuiController.Instance.StartServer;
            btnStop.Click += MainGuiController.Instance.StopServer;
            btnViewConfirmation.Click += MainGuiController.Instance.ViewConfirmation;
            btnLogout.Click += MainGuiController.Instance.Logout;
            this.FormClosed += MainGuiController.Instance.FormClosed;
        }
    }
}
