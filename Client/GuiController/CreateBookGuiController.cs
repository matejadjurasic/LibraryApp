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
    public class CreateBookGuiController
    {
        private static CreateBookGuiController instance;
        public static CreateBookGuiController Instance
        {
            get
            {
                if (instance == null) instance = new CreateBookGuiController();
                return instance;
            }
        }
        private FrmCreateBook frmCreateBook;
        private List<Pisac> writers = new List<Pisac>(); 

        internal void ShowFrmCreateBook()
        {
            frmCreateBook = new FrmCreateBook();
            frmCreateBook.AutoSize = true;
            Response r = Communication.Instance.GetAllAuthors();
            if (r.Exception == null && r.Result != null)
            {
                frmCreateBook.CboxWriters.DataSource = (List<Pisac>)r.Result;
            }
            frmCreateBook.ShowDialog();
        }

        internal void AddWriter(object sender, EventArgs e)
        {
            if(frmCreateBook.CboxWriters.SelectedIndex != -1)
            {
                if(writers.Contains(frmCreateBook.CboxWriters.SelectedItem as Pisac))
                {
                    MessageBox.Show("Pisac vec dodat", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    writers.Add(frmCreateBook.CboxWriters.SelectedItem as Pisac);
                    RefreshWriterTable();
                }
            }
        }

        private void RefreshWriterTable()
        {
            frmCreateBook.LstWriters.DataSource = null;
            frmCreateBook.LstWriters.DataSource = writers;
        }

        internal void DeleteWriter(object sender, EventArgs e)
        {
            if(frmCreateBook.LstWriters.SelectedIndex != -1)
            {
                writers.Remove(frmCreateBook.LstWriters.SelectedItem as Pisac);
                RefreshWriterTable();
            }
        }

        internal void AddBook(object sender, EventArgs e)
        {
            Knjiga book = new Knjiga
            {
                Ime = frmCreateBook.TxtName.Text,
                BrojKopija = (int)frmCreateBook.NumCopies.Value,
                BrojDostupnihKopija = (int)frmCreateBook.NumAvailableCopies.Value,
                Pisci = writers
            };

            if ((int)frmCreateBook.NumAvailableCopies.Value > (int)frmCreateBook.NumCopies.Value)
            {
                MessageBox.Show("Broj dostupnih kopija mora biti manji ili jednak od ukupnih kopija", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Response r = Communication.Instance.AddBook(book);
            if (r.Exception == null && (bool)r.Result == true)
            {
                MessageBox.Show("Sistem je zapamtio knjigu", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                writers.Clear();
                MainGuiController.Instance.RefreshBookTable();
                frmCreateBook.Dispose();
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti knjigu", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
