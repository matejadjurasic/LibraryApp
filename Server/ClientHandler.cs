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
                        r.Result = Controller.Instance.LoggedInUsers.Remove((Korisnik)req.Argument);
                        korisnik = null;
                        break;
                    case Operation.Exit:
                        r.Result = Controller.Instance.Clients.Remove(this);
                        isRunning = false;
                        //socket.Close();
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
