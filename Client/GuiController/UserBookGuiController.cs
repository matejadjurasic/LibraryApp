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
    public class UserBookGuiController
    {
        private static UserBookGuiController instance;
        public static UserBookGuiController Instance
        {
            get
            {
                if (instance == null) instance = new UserBookGuiController();
                return instance;
            }
        }
        private FrmUserBook frmUserBook;
        private Knjiga book;

        internal void ShowFrmUserBook(Knjiga book)
        {
            Response r = Communication.Instance.GetBook(book);
            if (r.Exception == null && r.Result != null)
            {
                this.book = (Knjiga)r.Result;
            }
            frmUserBook = new FrmUserBook();
            frmUserBook.AutoSize = true;
            frmUserBook.TxtName.Text = book.Ime;
            frmUserBook.TxtName.ReadOnly = true;
            frmUserBook.TxtNumAvailableCopies.Text = book.BrojDostupnihKopija.ToString();
            frmUserBook.TxtNumAvailableCopies.ReadOnly = true;
            RefreshWriters();

            MessageBox.Show("Sistem je ucitao podatke o izabranoј knjizi", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmUserBook.ShowDialog();
        }

        public void RefreshWriters()
        {
            frmUserBook.LstWriters.DataSource = null;
            frmUserBook.LstWriters.DataSource = book.Pisci;
        }
    }
}
