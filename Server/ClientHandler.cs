using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private Sender sender;
        private Receiver receiver;
        private Socket socket;
        private Korisnik korisnik;
        private Bibliotekar bibliotekar;
        private bool isRunning = true;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);
        }

        public void HandleRequest()
        {
            while (isRunning)
            {
                Request req = (Request)receiver.Receive();
                Response r = ProcessRequest(req);
                sender.Send(r);
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response r = new Response();
            try
            {
                switch (req.Operation)
                {
                    case Operation.Login:
                        r.Result = Controller.Instance.Login((Korisnik)req.Argument);
                        if(r.Result != null)
                        {
                            korisnik = (Korisnik)r.Result;
                        }
                        break;
                    case Operation.GetBooks:
                        r.Result = Controller.Instance.GetAllBooks();
                        break;
                    case Operation.SearchBooks:
                        r.Result = Controller.Instance.SearchBooks((string)req.Argument);
                        break;
                    case Operation.Logout:
                        if(korisnik != null)
                        {
                            r.Result = Controller.Instance.LoggedInUsers.Remove((Korisnik)req.Argument);
                            korisnik = null;
                        }
                        else
                        {
                            r.Result = Controller.Instance.LoggedInAdmins.Remove((Bibliotekar)req.Argument);
                            bibliotekar = null;
                        }
                        break;
                    case Operation.Exit:
                        r.Result = Controller.Instance.Clients.Remove(this);
                        isRunning = false;
                        //socket.Close();
                        break;
                    case Operation.UpdateBook:
                        r.Result = Controller.Instance.UpdateBook((Knjiga)req.Argument);
                        break;
                    case Operation.UpdateConfirmation:
                        r.Result = Controller.Instance.UpdateConfirmation((Potvrda)req.Argument);
                        break;
                    case Operation.UpdateUser:
                        r.Result = Controller.Instance.UpdateUser((Korisnik)req.Argument);
                        break;
                    case Operation.GetBook:
                        r.Result = Controller.Instance.GetBook((int)req.Argument);
                        break;
                    case Operation.GetAllConfirmations:
                        r.Result = Controller.Instance.GetAllConfirmations();
                        break;
                    case Operation.GettAllAuthors:
                        r.Result = Controller.Instance.GetAllAuthors();
                        break;
                    case Operation.GetConfirmationItems:
                        r.Result = Controller.Instance.GetConfirmationItems((int)req.Argument);
                        break;
                    case Operation.AddBook:
                        r.Result = Controller.Instance.SaveBook((Knjiga)req.Argument);
                        break;
                    case Operation.AddConfiramtion:
                        r.Result = Controller.Instance.SaveConfirmation((Potvrda)req.Argument);
                        break;
                    case Operation.LoginB:
                        r.Result = Controller.Instance.LoginB((Bibliotekar)req.Argument);
                        if (r.Result != null)
                        {
                            bibliotekar = (Bibliotekar)r.Result;
                        }
                        break;
                    case Operation.SaveWriter:
                        r.Result = Controller.Instance.SaveWriter((Pisac)req.Argument);
                        break;
                    case Operation.AddUser:
                        r.Result = Controller.Instance.SaveUser((Korisnik)req.Argument);
                        break;
                    case Operation.DeleteUser:
                        r.Result = Controller.Instance.DeleteUser((Korisnik)req.Argument);
                        break;
                    case Operation.SearchUsers:
                        r.Result = Controller.Instance.SearchUsers((string)req.Argument);
                        break;
                    case Operation.GetAllUsers:
                        r.Result = Controller.Instance.GetAllUsers();
                        break;

                }
            }
            catch (Exception ex)
            {
                r.Exception = ex;
                Debug.WriteLine(ex.Message);
            }
            return r;
        }

        /// <summary>
        /// ///////////////
        /// </summary>
        public void SendShutdownNotification()
        {
            try
            {
                Response shutdownResponse = new Response
                {
                    Result = "Server shutting down",
                    Operation = Operation.Shutdown
                };

                sender.Send(shutdownResponse);
                isRunning = false;
                //socket.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error sending shutdown notification: " + ex.Message);
            }
        }
    }
}
