using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.GuiControllers
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
            this.book = Controller.Instance.GetBook(book.KnjigaId);
            frmBook = new FrmBook();
            frmBook.AutoSize = true;
            frmBook.TxtName.Text = book.Ime;
            frmBook.TxtName.ReadOnly = true;
            frmBook.NumAvailableCopies.Value = book.BrojDostupnihKopija;
            frmBook.NumAvailableCopies.ReadOnly = true;
            frmBook.NumCopies.Value = book.BrojKopija;
            frmBook.NumCopies.ReadOnly = true;
            frmBook.CboxWriters.DataSource = Controller.Instance.GetAllAuthors();
            frmBook.CboxWriters.DisplayMember = "Ime";
            RefreshWriters();
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
                    MessageBox.Show("This writer is already associated with the book.", "Duplicate Writer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            frmBook.LstWriters.DisplayMember = "Ime";
        }

        internal void UpdateBook(object sender, EventArgs e)
        {
            book.Ime = frmBook.TxtName.Text;
            book.BrojKopija = (int)frmBook.NumCopies.Value;
            book.BrojDostupnihKopija = (int)frmBook.NumAvailableCopies.Value;

            if (Controller.Instance.UpdateBook(book,book.KnjigaId))
            {
                MessageBox.Show("Book updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainGuiController.Instance.RefreshBookTable();
                book.Pisci.Clear();
                frmBook.Dispose();
            }
            else
            {
                MessageBox.Show("Error updating book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
