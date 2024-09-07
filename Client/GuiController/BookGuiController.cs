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
    public class BookGuiController
    {
        private static BookGuiController instance;
        public static BookGuiController Instance
        {
            get
            {
                if (instance == null) instance = new BookGuiController();
                return instance;
            }
        }
        private FrmBook frmBook;
        private Knjiga book;

        internal void ShowFrmBook(Knjiga book)
        {
            Response r = Communication.Instance.GetBook(book.KnjigaId);
            if (r.Exception == null && r.Result != null)
            {
                this.book = (Knjiga)r.Result;
            }
            frmBook = new FrmBook();
            frmBook.AutoSize = true;
            frmBook.TxtName.Text = book.Ime;
            frmBook.TxtName.ReadOnly = true;
            frmBook.NumAvailableCopies.Value = book.BrojDostupnihKopija;
            frmBook.NumAvailableCopies.ReadOnly = true;
            frmBook.NumCopies.Value = book.BrojKopija;
            frmBook.NumCopies.ReadOnly = true;
            Response r2 = Communication.Instance.GetAllAuthors();
            if (r2.Exception == null && r2.Result != null)
            {
                frmBook.CboxWriters.DataSource = (List<Pisac>)r2.Result;
                RefreshWriters();
            }
            MessageBox.Show("Sistem je ucitao podatke o izabranoј knjizi", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmBook.ShowDialog();
        }

        internal void Checked(object sender, EventArgs e)
        {
            if (frmBook.CheckUpdate.Checked)
            {
                frmBook.TxtName.ReadOnly = false;
                frmBook.NumAvailableCopies.ReadOnly = false;
                frmBook.NumCopies.ReadOnly = false;
            }
            else
            {
                frmBook.TxtName.ReadOnly = true;
                frmBook.NumAvailableCopies.ReadOnly = true;
                frmBook.NumCopies.ReadOnly = true;
            }
        }

        internal void AddWriter(object sender, EventArgs e)
        {
            if(frmBook.CboxWriters.SelectedIndex != -1)
            {
                Pisac selectedWriter = frmBook.CboxWriters.SelectedItem as Pisac;
                if (!book.Pisci.Contains(selectedWriter))
                {
                    book.Pisci.Add(selectedWriter);
                    RefreshWriters();
                }
                else
                {
                    MessageBox.Show("Vec ste dodali ovog pisca.", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        internal void DeleteWriter(object sender, EventArgs e)
        {
            if (frmBook.LstWriters.SelectedIndex != -1)
            {
                Pisac selectedWriter = frmBook.LstWriters.SelectedItem as Pisac;
                book.Pisci.Remove(selectedWriter);
                RefreshWriters();
            }
        }

        public void RefreshWriters()
        {
            frmBook.LstWriters.DataSource = null;
            frmBook.LstWriters.DataSource = book.Pisci;
        }

        internal void UpdateBook(object sender, EventArgs e)
        {
            book.Ime = frmBook.TxtName.Text;
            book.BrojKopija = (int)frmBook.NumCopies.Value;
            book.BrojDostupnihKopija = (int)frmBook.NumAvailableCopies.Value;

            if((int)frmBook.NumAvailableCopies.Value > (int)frmBook.NumCopies.Value)
            {
                MessageBox.Show("Broj dostupnih kopija mora biti manji ili jednak od ukupnih kopija", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Response r = Communication.Instance.UpdateBook(book);
            if (r.Exception == null && (bool)r.Result == true)
            {
                MessageBox.Show("Sistem je zapamtio nove podatke o knjizi", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainGuiController.Instance.RefreshBookTable();
                book.Pisci.Clear();
                frmBook.Dispose();
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti knjigu", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
