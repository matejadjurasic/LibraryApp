using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.GuiControllers
{
    public class ConfirmationGuiController
    {
        private static ConfirmationGuiController instance;
        public static ConfirmationGuiController Instance
        {
            get
            {
                if (instance == null) instance = new ConfirmationGuiController();
                return instance;
            }
        }
        private FrmConfirmation frmConfirmation;
        private Potvrda confirmation;
        private List<StavkaPotvrde> items = new List<StavkaPotvrde>();

        internal void ShowFrmConfirmation(Potvrda confirmation)
        {
            this.confirmation = confirmation;
            frmConfirmation = new FrmConfirmation();
            frmConfirmation.AutoSize = true;
            frmConfirmation.TxtDate.Text = confirmation.DatumOd.ToString();
            frmConfirmation.TxtLibrarian.Text = $"{confirmation.Bibliotekar.Ime} {confirmation.Bibliotekar.Prezime}";
            frmConfirmation.TxtUser.Text = $"{confirmation.Korisnik.Ime} {confirmation.Korisnik.Prezime}";
            frmConfirmation.CboxStatus.Checked = confirmation.Returned;
            if (frmConfirmation.CboxStatus.Checked)
            {
                frmConfirmation.CboxStatus.Enabled = false;
                frmConfirmation.BtnUpdate.Enabled = false;
            }
            frmConfirmation.LstItems.View = View.Details;
            frmConfirmation.LstItems.Columns.Add("Knjiga", 100, HorizontalAlignment.Left);
            frmConfirmation.LstItems.Columns.Add("Kolicina", 70, HorizontalAlignment.Left);
            items = Controller.Instance.GetConfirmationItems(confirmation.PotvrdaId);
            confirmation.Stavke = items;
            RefreshItemTable();
            frmConfirmation.ShowDialog();
        }

        public void RefreshItemTable()
        {
            if(items != null)
            {
                foreach (StavkaPotvrde item in items)
                {
                    ListViewItem item2 = new ListViewItem(item.Knjiga.Ime);
                    item2.SubItems.Add(item.Kolicina.ToString());
                    frmConfirmation.LstItems.Items.Add(item2);
                }
            }
        }

        internal void UpdateConfirmation(object sender, EventArgs e)
        {
            if(frmConfirmation.CboxStatus.Checked)
            {
                confirmation.Returned = true;
                if (Controller.Instance.UpdateConfirmation(confirmation, confirmation.PotvrdaId))
                {
                    MessageBox.Show("Uspjeh");
                    MainGuiController.Instance.RefreshConfirmationTable();
                    MainGuiController.Instance.RefreshBookTable();
                    frmConfirmation.Dispose();
                }
                else
                {
                    MessageBox.Show("Greska");
                }
            }  
        }
    }
}
