using Common.Domain;
using DBBroker;
using Server.GuiControllers;
using Server.SystemOperation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Controller
    {
        private Broker broker;
        private List<ClientHandler> clients = new List<ClientHandler>();  
        private List<Korisnik> loggedInUsers = new List<Korisnik>();
        private List<Bibliotekar> loggedInAdmins = new List<Bibliotekar>();

        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();
                return instance;
            }
        }

        public List<ClientHandler> Clients { get => clients; set => clients = value; }
        public List<Korisnik> LoggedInUsers { get => loggedInUsers; set => loggedInUsers = value; }
        public List<Bibliotekar> LoggedInAdmins { get => loggedInAdmins; set => loggedInAdmins = value; }

        private Controller() { broker = new Broker(); }
        
        public Korisnik Login(Korisnik korisnik)
        {
            NadjiKorisnikaSO so = new NadjiKorisnikaSO(korisnik);
            so.ExecuteTemplate();
            if(so.Result != null && !loggedInUsers.Contains(so.Result))
            {
                loggedInUsers.Add(so.Result);
                ServerGuiController.Instance.RefreshUserTable();
            }
            return so.Result;
        }

        public Bibliotekar LoginB(Bibliotekar bibliotekar)
        {
            NadjiBibliotekaraSO so = new NadjiBibliotekaraSO(bibliotekar);
            so.ExecuteTemplate();
            if (so.Result != null && !loggedInAdmins.Contains(so.Result))
            {
                loggedInAdmins.Add(so.Result);
                ServerGuiController.Instance.RefreshLibrarianTable();
            }
            return so.Result;
        }

        public bool SaveWriter(Pisac pisac)
        {
            SacuvajPiscaSO so = new SacuvajPiscaSO(pisac);
            so.ExecuteTemplate();
            return so.Result;
        }

        public bool SaveUser(Korisnik korisnik)
        {
            SacuvajKorisnikaSO so = new SacuvajKorisnikaSO(korisnik);
            so.ExecuteTemplate();
            return so.Result;
        }

        public bool UpdateUser(Korisnik korisnik)
        {
            ZapamtiKorisnikaSO so = new ZapamtiKorisnikaSO(korisnik);
            so.ExecuteTemplate();
            return so.Result;
        }

        public bool DeleteUser(Korisnik korisnik)
        {
            ObrisiKorisnikaSO so = new ObrisiKorisnikaSO(korisnik, korisnik.KorisnikId);
            so.ExecuteTemplate();
            return so.Result;
        }

        public bool SaveBook(Knjiga knjiga)
        {
            SacuvajKnjiguSO so = new SacuvajKnjiguSO(knjiga);
            so.ExecuteTemplate();
            return so.Result;
        }

        public bool UpdateBook(Knjiga knjiga)
        {
            ZapamtiKnjiguSO so = new ZapamtiKnjiguSO(knjiga, knjiga.KnjigaId);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Knjiga> SearchBooks(string searchValue)
        {
            NadjiKnjigeSO so = new NadjiKnjigeSO(searchValue);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Korisnik> SearchUsers(string searchValue)
        {
            NadjiKorisnikeSO so = new NadjiKorisnikeSO(searchValue);
            so.ExecuteTemplate();
            return so.Result;
        }

        public bool SaveConfirmation(Potvrda potvrda)
        {
            SacuvajPotvrduSO so = new SacuvajPotvrduSO(potvrda);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Knjiga> GetAllBooks()
        {
            UcitajListuKnjigaSO so = new UcitajListuKnjigaSO();
            so.ExecuteTemplate(); 
            return so.Result;
        }

        public List<Korisnik> GetAllUsers()
        {
            UcitajListuKorisnikaSO so = new UcitajListuKorisnikaSO();
            so.ExecuteTemplate(); 
            return so.Result;
        }

        public List<Pisac> GetAllAuthors()
        {
            UcitajListuPisacaSO so = new UcitajListuPisacaSO();
            so.ExecuteTemplate(); 
            return so.Result;
        }

        public Korisnik GetUser(int userId)
        {
            UcitajKorisnikaSO so = new UcitajKorisnikaSO(userId);
            so.ExecuteTemplate();  
            return so.Result;
        }

        public Knjiga GetBook(int bookId)
        {
            UcitajKnjiguSO so = new UcitajKnjiguSO(bookId);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Potvrda> GetAllConfirmations()
        {
            UcitajListuPotvrdaSO so = new UcitajListuPotvrdaSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<StavkaPotvrde> GetConfirmationItems(int potvrdaId)
        {
            UcitajListuStavkiSO so = new UcitajListuStavkiSO(potvrdaId);
            so.ExecuteTemplate();
            return so.Result;
        }

        public bool UpdateConfirmation(Potvrda potvrda)
        {
            ZapamtiPotvrduSO so = new ZapamtiPotvrduSO(potvrda);
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
