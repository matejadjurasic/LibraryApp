using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client.GuiController
{
    public class MainGuiController
    {
        private static MainGuiController instance;
        public static MainGuiController Instance 
        { 
            get 
            { 
                if (instance == null) instance = new MainGuiController();
                return instance; 
            } 
        }
        private FrmMain frmMain;
        private Bibliotekar bibliotekar;
        private List<Potvrda> confirmations = new List<Potvrda>();
        private bool isExitClose = true;

        internal void ShowFrmMain(Bibliotekar bibliotekar)
        {
            frmMain = new FrmMain();
            this.bibliotekar = bibliotekar;
            isExitClose = true;
            frmMain.AutoSize = true;
            RefreshUserTable();
            RefreshBookTable();
            frmMain.TxtLoggedIn.Text = $"{bibliotekar.Ime} {bibliotekar.Prezime}";
            frmMain.LstConfirmations.View = View.Details;
            frmMain.LstConfirmations.Columns.Add("Id", 50, HorizontalAlignment.Left);
            frmMain.LstConfirmations.Columns.Add("Korisnik", 70, HorizontalAlignment.Left);
            frmMain.LstConfirmations.Columns.Add("Datum", 130, HorizontalAlignment.Left);
            frmMain.LstConfirmations.Columns.Add("Bibliotekar", 80, HorizontalAlignment.Left);
            frmMain.LstConfirmations.Columns.Add("Status",80,HorizontalAlignment.Left);
            Response r = Communication.Instance.GetAllConfirmations();
            if(r.Exception == null && r.Result != null)
            {
                confirmations = (List<Potvrda>)r.Result;
            }
            RefreshConfirmationTable();
            frmMain.ShowDialog();
        }

        public void RefreshUserTable()
        {
            Response r = Communication.Instance.GetAllUsers();
            if (r.Exception == null && r.Result != null)
            {
                frmMain.LstUsers.DataSource = null;
                frmMain.LstUsers.DataSource = (List<Korisnik>)r.Result;
                frmMain.LstBooks.DisplayMember = "Ime";
            }
            else
            {
                MessageBox.Show("Greska pri osvezavanju tabele korisnika", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshBookTable()
        {
            Response r = Communication.Instance.GetBooks();
            if (r.Exception == null && r.Result != null)
            {
                frmMain.LstBooks.DataSource = null;
                frmMain.LstBooks.DataSource = (List<Knjiga>)r.Result;
                frmMain.LstBooks.DisplayMember = "Ime";
            }
            else
            {
                MessageBox.Show("Greska pri osvezavanju tabele knjiga", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshConfirmationTable()
        {
            Response r = Communication.Instance.GetAllConfirmations();
            if (r.Exception == null && r.Result != null)
            {
                confirmations.Clear();
                confirmations = (List<Potvrda>)r.Result;
                frmMain.LstConfirmations.Items.Clear();
                foreach (Potvrda confirmation in confirmations)
                {
                    ListViewItem item = new ListViewItem(confirmation.PotvrdaId.ToString());
                    item.SubItems.Add(confirmation.Korisnik.Ime);
                    item.SubItems.Add(confirmation.DatumOd.ToString());
                    item.SubItems.Add(confirmation.Bibliotekar.Ime);
                    item.SubItems.Add(confirmation.Returned ? "Razduzeno" : "Zaduzeno");
                    frmMain.LstConfirmations.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Greska pri osvezavanju tabele potvrda", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void MakeNewUser(object sender, EventArgs e)
        {
            CreateUserGuiController.Instance.ShowFrmCreateUser();
        }

        internal void MakeNewWriter(object sender, EventArgs e)
        {
            CreateWriterGuiController.Instance.ShowFrmCreateWriter();
        }

        internal void MakeNewBook(object sender, EventArgs e)
        {
            CreateBookGuiController.Instance.ShowFrmCreateBook();
        }

        internal void DeleteUser(object sender, EventArgs e)
        {
            if(frmMain.LstUsers.SelectedIndex != -1)
            {
                Korisnik user = frmMain.LstUsers.SelectedItem as Korisnik;
                Response r = Communication.Instance.DeleteUser(user);
                if (r.Exception == null && (bool)r.Result == true)
                {
                    MessageBox.Show("Sistem je obrisao korisnika", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUserTable();
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da obrise korisnika", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        internal void AddConfirmation(object sender, EventArgs e)
        {
            AddConfirmationGuiController.Instance.ShowFrmAddConfirmation(bibliotekar);
        }

        internal void Search(object sender, EventArgs e)
        {
            Response r = Communication.Instance.SearchBooks(frmMain.TxtSearchTerm.Text);
            if (r.Exception == null && r.Result != null)
            {
                frmMain.LstBooks.DataSource = null;
                frmMain.LstBooks.DataSource = (List<Knjiga>)r.Result;
                frmMain.LstBooks.DisplayMember = "Ime";
            }
            else
            {
                frmMain.TxtSearchTerm.Text = "";
                MessageBox.Show("Sistem ne moze da nadje knjige po zadatoj vrednosti", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void SearchUsers(object sender, EventArgs e)
        {
            Response r = Communication.Instance.SearchUsers(frmMain.TxtSearchUsers.Text);
            if (r.Exception == null && r.Result != null)
            {
                frmMain.LstUsers.DataSource = null;
                frmMain.LstUsers.DataSource = (List<Korisnik>)r.Result;
                frmMain.LstBooks.DisplayMember = "Ime";
            }
            else
            {
                frmMain.TxtSearchUsers.Text = "";  
                MessageBox.Show("Sistem ne moze da nadje korisnike po zadatoj vrednosti", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void ViewUser(object sender, EventArgs e)
        {
            if(frmMain.LstUsers.SelectedIndex != -1)
            {
                try
                {
                    UserGuiController.Instance.ShowFrmUser(frmMain.LstUsers.SelectedItem as Korisnik);
                }
                catch
                {
                    MessageBox.Show("Sistem ne moze da ucita korisnika", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal void ViewBook(object sender, EventArgs e)
        {
            if(frmMain.LstBooks.SelectedIndex != -1)
            {
                try
                {
                    BookGuiController.Instance.ShowFrmBook(frmMain.LstBooks.SelectedItem as Knjiga);
                }
                catch
                {
                    MessageBox.Show("Sistem ne moze da ucita knjigu", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        internal void ViewConfirmation(object sender, EventArgs e)
        {
            if (frmMain.LstConfirmations.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = frmMain.LstConfirmations.SelectedItems[0];
                int confirmationId = int.Parse(selectedItem.Text);
                Potvrda confirmation = confirmations.FirstOrDefault(c => c.PotvrdaId == confirmationId);
                if (confirmation != null)
                {
                    try
                    { 
                        ConfirmationGuiController.Instance.ShowFrmConfirmation(confirmation);
                    }
                    catch
                    {
                        MessageBox.Show("Sistem ne moze da ucita potvrdu", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        internal void Logout(object sender, EventArgs e)
        {
            Response r = Communication.Instance.Logout(bibliotekar);
            if (r.Exception == null && (bool)r.Result == true)
            {
                LoginGuiController.Instance.SetVisible();
                isExitClose = false;
                frmMain.Close();
            }
            else
            {
                MessageBox.Show("Greska pri autentikaciji", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExitClose)
            {
                Logout(sender, e);
            }
        }
    }
}
