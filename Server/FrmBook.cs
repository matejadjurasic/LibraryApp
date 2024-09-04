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
    public partial class FrmBook : Form
    {
        public FrmBook()
        {
            InitializeComponent();
            checkUpdate.CheckedChanged += BookGuiController.Instance.Checked;
            btnAddWriters.Click += BookGuiController.Instance.AddWriter;
            btnDeleteWriter.Click += BookGuiController.Instance.DeleteWriter;
            btnUpdateBook.Click += BookGuiController.Instance.UpdateBook;
        }
    }
}
