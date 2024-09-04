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
    public partial class FrmAddConfirmation : Form
    {
        public FrmAddConfirmation()
        {
            InitializeComponent();
            btnAddItem.Click += AddConfirmationGuiController.Instance.AddItem;
            btnAddConfirmation.Click += AddConfirmationGuiController.Instance.AddConfirmation;
            btnRemoveItem.Click += AddConfirmationGuiController.Instance.RemoveItem;
        }
    }
}
