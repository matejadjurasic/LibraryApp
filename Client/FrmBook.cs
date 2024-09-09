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
    public partial class FrmBook : Form
    {
        public FrmBook()
        {
            InitializeComponent();
            btnAddWriters.Click += BookGuiController.Instance.AddWriter;
            btnDeleteWriter.Click += BookGuiController.Instance.DeleteWriter;
            btnUpdateBook.Click += BookGuiController.Instance.UpdateBook;
        }
    }
}
