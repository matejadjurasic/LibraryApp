using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.GuiControllers
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
            frmCreateBook.CboxWriters.DataSource = Controller.Instance.GetAllAuthors();
            frmCreateBook.CboxWriters.DisplayMember = "Ime";
            frmCreateBook.ShowDialog();
        }

        internal void AddWriter(object sender, EventArgs e)
        {
            if(frmCreateBook.CboxWriters.SelectedIndex != -1)
            {
                if(writers.Contains(frmCreateBook.CboxWriters.SelectedItem as Pisac))
                {
                    MessageBox.Show("Pisac vec dodat");
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
            frmCreateBook.LstWriters.DisplayMember = "Ime";
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


            if(Controller.Instance.SaveBook(book))
            {
                MessageBox.Show("Uspjesno dodata knjiga");
                writers.Clear();
                MainGuiController.Instance.RefreshBookTable();
                frmCreateBook.Dispose();
            }
            else
            {
                MessageBox.Show("Greska pri dodavanju");
            }
        }
    }
}
