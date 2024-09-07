using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
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
            frmConfirmation.LstItems.Columns.Add("Knjiga", 200, HorizontalAlignment.Left);
            frmConfirmation.LstItems.Columns.Add("Kolicina", 70, HorizontalAlignment.Left);
            Response r = Communication.Instance.GetConfirmationItems(confirmation.PotvrdaId);
            if (r.Exception == null && r.Result != null)
            {
                items = (List<StavkaPotvrde>)r.Result;
            }
            confirmation.Stavke = items;
            RefreshItemTable();
            MessageBox.Show("Sistem je ucitao podatke o izabranoj potvrdi", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Response r = Communication.Instance.UpdateConfirmation(confirmation);
                if (r.Exception == null && (bool)r.Result == true)
                {
                    MessageBox.Show("Sistem je zapamtio nove podatke o potvrdi", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainGuiController.Instance.RefreshConfirmationTable();
                    MainGuiController.Instance.RefreshBookTable();
                    frmConfirmation.Dispose();
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da zapamti potvrdu", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }  
        }
    }
}
