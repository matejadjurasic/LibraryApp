using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class Communication
    {
        private static Communication _instance;
        public static Communication Instance
        {
            get
            {
                if (_instance == null) _instance = new Communication();
                return _instance;
            }
        }
        private Communication()
        {

        }

        Socket socket;
        Sender sender;
        Receiver receiver;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            sender = new Sender(socket);
            receiver = new Receiver(socket);

            //Thread listenThread = new Thread(ListenForResponses);
            //listenThread.Start();
        }

        /// <summary>
        /// /////////////////
        /// </summary>
        private void ListenForResponses()
        {
            while (true)
            {
                try
                {
                    Response response = (Response)receiver.Receive();
                    if (response.Operation == Operation.Shutdown)
                    {
                        MessageBox.Show("Server is shutting down, the application will now close.", "Shutdown", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error receiving shutdown notification: " + ex.Message);
                }
            }
        }

        internal Response Login(Korisnik korisnik)
        {
            Request req = new Request
            {
                Argument = korisnik,
                Operation = Operation.Login
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetBooks()
        {
            Request req = new Request
            {
                Operation = Operation.GetBooks
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response SearchBooks(string searchTerm)
        {
            Request req = new Request
            {
                Argument = searchTerm,
                Operation = Operation.SearchBooks
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response Logout(Korisnik korisnik)
        {
            Request req = new Request
            {
                Argument = korisnik,
                Operation = Operation.Logout
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response Exit()
        {
            Request req = new Request
            {
                Operation = Operation.Exit,
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }
    }
}
