using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class UserMainGuiController
    {
        private static UserMainGuiController instance;
        public static UserMainGuiController Instance 
        { 
            get 
            {
                if (instance == null) instance = new UserMainGuiController();
                return instance; 
            } 
        }
        public UserMainGuiController()
        {

        }

        private FrmUserMain frmMain;
        private Korisnik korisnik;
        private List<Knjiga> books = new List<Knjiga>();
        private bool exitClose;

        internal void ShowFrmMain(Korisnik k)
        {
            frmMain = new FrmUserMain();
            korisnik = k;
            exitClose = true;
            frmMain.AutoSize = true;
            frmMain.TxtLoggedIn.Text = $"{k.Ime} {k.Prezime}";
            frmMain.LstBooks.View = View.Details;
            frmMain.LstBooks.Columns.Add("Id",50,HorizontalAlignment.Left);
            frmMain.LstBooks.Columns.Add("Knjiga", 150, HorizontalAlignment.Left);
            frmMain.LstBooks.Columns.Add("Broj Dostupnih Kopija", 150, HorizontalAlignment.Left);
            GetBooks();
            RefreshBooks();
            frmMain.ShowDialog();
        }

        public void GetBooks()
        {
            Response r = Communication.Instance.GetBooks();
            if (r.Exception == null && r.Result != null)
            {
                books = (List<Knjiga>)r.Result;
            }
        }

        public void RefreshBooks()
        {
            if (frmMain.InvokeRequired)
            {
                frmMain.Invoke(new MethodInvoker(RefreshBooks));
                return;
            }
            frmMain.LstBooks.Items.Clear();
            if (books != null)
            {
                foreach (Knjiga book in books)
                {
                    ListViewItem item = new ListViewItem(book.KnjigaId.ToString());
                    item.SubItems.Add(book.Ime);
                    item.SubItems.Add(book.BrojDostupnihKopija.ToString());
                    frmMain.LstBooks.Items.Add(item);
                }
            }
        }

        internal void Logout(object sender, EventArgs e)
        {
            Response r = Communication.Instance.Logout(korisnik);
            if (r.Exception == null && (bool)r.Result == true)
            {
                LoginGuiController.Instance.SetVisible();
                exitClose = false;
                frmMain.Close();
            }
            else
            {
                MessageBox.Show("Greska pri logoutu", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void Search(object sender, EventArgs e)
        {
            Response r = Communication.Instance.SearchBooks(frmMain.TxtSearchTerm.Text);
            if (r.Exception == null && r.Result != null)
            {
                books.Clear();
                books = (List<Knjiga>)r.Result;
            }
            else
            {
                frmMain.TxtSearchTerm.Text = "";
                MessageBox.Show("Sistem ne moze da nadje knjige po zadatoj vrednosti", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshBooks();
        }

        internal void ViewBook(object sender, EventArgs e)
        {
            if (frmMain.LstBooks.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = frmMain.LstBooks.SelectedItems[0];
                int bookId = int.Parse(selectedItem.Text);
                Knjiga book = books.FirstOrDefault(c => c.KnjigaId == bookId);
                if (book != null)
                {
                    try
                    {
                        UserBookGuiController.Instance.ShowFrmUserBook(book);
                    }
                    catch
                    {
                        MessageBox.Show("Sistem ne moze da ucita knjigu", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        internal void FormClosed(object sender, FormClosedEventArgs e)
        {
            if(exitClose)
            {
                Logout(sender, e);
            }
        }
    }
}
