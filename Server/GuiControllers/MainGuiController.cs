using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Server.GuiControllers
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
        private Server server;
        private List<Potvrda> confirmations = new List<Potvrda>();
        private bool isExitClose = true;

        internal void ShowFrmMain(Bibliotekar bibliotekar, bool serverStatus)
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
            frmMain.LstConfirmations.Columns.Add("Korisnik", 150, HorizontalAlignment.Left);
            frmMain.LstConfirmations.Columns.Add("Datum", 100, HorizontalAlignment.Left);
            frmMain.LstConfirmations.Columns.Add("Bibliotekar", 150, HorizontalAlignment.Left);
            frmMain.LstConfirmations.Columns.Add("Status",100,HorizontalAlignment.Left);
            confirmations = Controller.Instance.GetAllConfirmations();
            RefreshConfirmationTable();
            if (serverStatus)
            {
                frmMain.BtnStart.Enabled = false;
            }
            else
            {
                frmMain.BtnStop.Enabled = false;
            }
            frmMain.ShowDialog();
        }

        public void RefreshUserTable()
        {
            frmMain.LstUsers.DataSource = null;
            frmMain.LstUsers.DataSource = Controller.Instance.GetAllUsers();
            frmMain.LstUsers.DisplayMember = "Ime";
        }

        public void RefreshBookTable()
        {
            frmMain.LstBooks.DataSource = null;
            frmMain.LstBooks.DataSource = Controller.Instance.GetAllBooks();
            frmMain.LstBooks.DisplayMember = "Ime";
        }

        public void RefreshConfirmationTable()
        {
            confirmations.Clear();
            confirmations = Controller.Instance.GetAllConfirmations();
            frmMain.LstConfirmations.Items.Clear();
            if (confirmations != null)
            {
                foreach (Potvrda confirmation in confirmations)
                {
                    ListViewItem item = new ListViewItem(confirmation.PotvrdaId.ToString());
                    item.SubItems.Add(confirmation.Korisnik.Ime);
                    item.SubItems.Add(confirmation.DatumOd.ToString());
                    item.SubItems.Add(confirmation.Bibliotekar.Ime);
                    item.SubItems.Add(confirmation.Returned ? "Yes" : "No");
                    frmMain.LstConfirmations.Items.Add(item);
                }
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
                if (Controller.Instance.DeleteUser(user,user.KorisnikId))
                {
                    MessageBox.Show("Korisnik izbrisan");
                    RefreshUserTable();
                }
                else
                {
                    MessageBox.Show("Greska pri brisanju");
                }
            }
            
        }

        internal void AddConfirmation(object sender, EventArgs e)
        {
            AddConfirmationGuiController.Instance.ShowFrmAddConfirmation(bibliotekar);
        }

        internal void Search(object sender, EventArgs e)
        {
            frmMain.LstBooks.DataSource = null;
            frmMain.LstBooks.DataSource = Controller.Instance.SearchBooks(frmMain.TxtSearchTerm.Text);
            frmMain.LstBooks.DisplayMember = "Ime";
        }

        internal void SearchUsers(object sender, EventArgs e)
        {
            frmMain.LstUsers.DataSource = null;
            frmMain.LstUsers.DataSource = Controller.Instance.SearchUsers(frmMain.TxtSearchUsers.Text);
            frmMain.LstUsers.DisplayMember = "Ime";
        }

        internal void ViewUser(object sender, EventArgs e)
        {
            if(frmMain.LstUsers.SelectedIndex != -1)
            {
                UserGuiController.Instance.ShowFrmUser(frmMain.LstUsers.SelectedItem as Korisnik);
            }
        }

        internal void ViewBook(object sender, EventArgs e)
        {
            if(frmMain.LstBooks.SelectedIndex != -1)
            {
                BookGuiController.Instance.ShowFrmBook(frmMain.LstBooks.SelectedItem as Knjiga);
            }
        }

        internal void StartServer(object sender, EventArgs e)
        {
            server = new Server();
            frmMain.BtnStart.Enabled = false;
            frmMain.BtnStop.Enabled = true;
            server.Start();
        }

        internal void StopServer(object sender, EventArgs e)
        {
            frmMain.BtnStart.Enabled = true;
            frmMain.BtnStop.Enabled = false;
            server.Stop();
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
                    ConfirmationGuiController.Instance.ShowFrmConfirmation(confirmation);
                }
            }
        }

        internal void Logout(object sender, EventArgs e)
        {
            LoginGuiController.Instance.Server = server;
            LoginGuiController.Instance.ServerStatus = frmMain.BtnStop.Enabled;
            LoginGuiController.Instance.SetVisible();
            isExitClose = false;
            frmMain.Close();
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
