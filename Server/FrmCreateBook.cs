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
    public partial class FrmCreateBook : Form
    {
        public FrmCreateBook()
        {
            InitializeComponent();
            btnAddWriter.Click += CreateBookGuiController.Instance.AddWriter;
            btnDeleteWriter.Click += CreateBookGuiController.Instance.DeleteWriter;
            btnAddBook.Click += CreateBookGuiController.Instance.AddBook;
        }
    }
}
