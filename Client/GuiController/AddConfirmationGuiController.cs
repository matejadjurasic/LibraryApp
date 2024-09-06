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
    public class AddConfirmationGuiController
        {
        private static AddConfirmationGuiController instance;
        public static AddConfirmationGuiController Instance
        {
            get
            {
                if (instance == null) instance = new AddConfirmationGuiController();
                return instance;
            }
        }
        private FrmAddConfirmation frmAddConfirmation;
        private Bibliotekar bibliotekar;
        private Potvrda potvrda = new Potvrda();
        private List<StavkaPotvrde> items = new List<StavkaPotvrde>();

        internal void ShowFrmAddConfirmation(Bibliotekar bibliotekar)
        {
            this.bibliotekar = bibliotekar;
            frmAddConfirmation = new FrmAddConfirmation();
            frmAddConfirmation.AutoSize = true;
            Response r = Communication.Instance.GetAllUsers();
            if (r.Exception == null && r.Result != null)
            {
                frmAddConfirmation.CboxUser.DataSource = (List<Korisnik>)r.Result;
                frmAddConfirmation.CboxUser.DisplayMember = "Ime";
            }
            
            Response r2 = Communication.Instance.GetBooks();
            if (r2.Exception == null && r2.Result != null)
            {
                frmAddConfirmation.CboxBook.DataSource = (List<Knjiga>)r2.Result;
                frmAddConfirmation.CboxBook.DisplayMember = "Ime";
            }
            frmAddConfirmation.LstItems.View = View.Details;
            frmAddConfirmation.LstItems.Columns.Add("Knjiga", 150, HorizontalAlignment.Left);
            frmAddConfirmation.LstItems.Columns.Add("Kolicina", 150, HorizontalAlignment.Left);
            frmAddConfirmation.ShowDialog();
        }

        internal void AddItem(object sender, EventArgs e)
        {
            if (frmAddConfirmation.CboxBook.SelectedIndex != -1)
            {
                if (frmAddConfirmation.NumAmount.Value <= 0)
                {
                    MessageBox.Show("Kolicina mora biti veca od nule", "Los unos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Knjiga selectedBook = frmAddConfirmation.CboxBook.SelectedItem as Knjiga;

                if (frmAddConfirmation.NumAmount.Value > selectedBook.BrojDostupnihKopija)
                {
                    MessageBox.Show("Nedovoljno dostupnih knjiga", "Los unos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool bookAlreadyAdded = items.Any(item1 => item1.Knjiga.KnjigaId == selectedBook.KnjigaId);

                if (bookAlreadyAdded)
                {
                    MessageBox.Show("Ova knjiga je vec dodata.", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                StavkaPotvrde item = new StavkaPotvrde
                {
                    Knjiga = selectedBook,
                    Potvrda = potvrda,
                    Kolicina = (int)frmAddConfirmation.NumAmount.Value
                };
                items.Add(item);
                RefreshItems();
            }
        }

        internal void AddConfirmation(object sender, EventArgs e)
        {
            potvrda.Stavke = items;
            potvrda.Bibliotekar = bibliotekar;
            if (frmAddConfirmation.CboxUser.SelectedIndex != -1)
            {
                potvrda.Korisnik = frmAddConfirmation.CboxUser.SelectedItem as Korisnik;
            }
            potvrda.DatumOd = DateTime.Now;

            Response r = Communication.Instance.AddConfirmation(potvrda);
            if (r.Exception == null && (bool)r.Result == true)
            {
                MessageBox.Show("Potvrda uspesno dodata", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmAddConfirmation.LstItems.Items.Clear();
                MainGuiController.Instance.RefreshBookTable();
                MainGuiController.Instance.RefreshConfirmationTable();
                frmAddConfirmation.Dispose();
            }
            else
            {
                MessageBox.Show("Greska pri dodavanju", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void RemoveItem(object sender, EventArgs e)
        {
            if (frmAddConfirmation.LstItems.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = frmAddConfirmation.LstItems.SelectedItems[0];
                string bookName = selectedItem.Text;
                StavkaPotvrde itemToRemove = items.FirstOrDefault(item => item.Knjiga.Ime == bookName);

                if (itemToRemove != null)
                {

                    items.Remove(itemToRemove);
                    RefreshItems();
                }
            }
        }

        private void RefreshItems()
        {
            frmAddConfirmation.LstItems.Items.Clear();
            if (items.Count > 0)
            {
                foreach (StavkaPotvrde item in items)
                {
                    ListViewItem item2 = new ListViewItem(item.Knjiga.Ime);
                    item2.SubItems.Add(item.Kolicina.ToString());
                    frmAddConfirmation.LstItems.Items.Add(item2);
                }
            }
        }
    }
}
