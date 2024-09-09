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

        internal Response Logout(IEntity entity)
        {
            Request req = new Request
            {
                Argument = entity,
                Operation = Operation.Logout
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetAllConfirmations()
        {
            Request req = new Request
            {
                Operation = Operation.GetAllConfirmations,
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetAllUsers()
        {
            Request req = new Request
            {
                Operation = Operation.GetAllUsers,
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response DeleteUser(Korisnik korisnik)
        {
            Request req = new Request
            {
                Argument = korisnik,
                Operation = Operation.DeleteUser
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response SearchUsers(string searchTerm)
        {
            Request req = new Request
            {
                Argument = searchTerm,
                Operation = Operation.SearchUsers
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response UpdateUser(Korisnik updatedUser)
        {
            Request req = new Request
            {
                Argument = updatedUser,
                Operation = Operation.UpdateUser
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response SaveWriter(Pisac writer)
        {
            Request req = new Request
            {
                Argument = writer,
                Operation = Operation.SaveWriter
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response AddUser(Korisnik korisnik)
        {
            Request req = new Request
            {
                Argument = korisnik,
                Operation = Operation.AddUser
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response AddBook(Knjiga book)
        {
            Request req = new Request
            {
                Argument = book,
                Operation = Operation.AddBook
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetAllAuthors()
        {
            Request req = new Request
            {
                Operation = Operation.GettAllAuthors
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response UpdateBook(Knjiga book)
        {
            Request req = new Request
            {
                Argument = book,
                Operation = Operation.UpdateBook
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetBook(Knjiga book)
        {
            Request req = new Request
            {
                Argument = book,
                Operation = Operation.GetBook
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response UpdateConfirmation(Potvrda confirmation)
        {
            Request req = new Request
            {
                Argument = confirmation,
                Operation = Operation.UpdateConfirmation
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response GetConfirmationItems(int potvrdaId)
        {
            Request req = new Request
            {
                Argument = potvrdaId,
                Operation = Operation.GetConfirmationItems
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response AddConfirmation(Potvrda potvrda)
        {
            Request req = new Request
            {
                Argument = potvrda,
                Operation = Operation.AddConfiramtion
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal Response LoginB(Bibliotekar b)
        {
            Request req = new Request
            {
                Argument = b,
                Operation = Operation.LoginB
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }

        internal void Disconnect()
        {
            Request req = new Request
            {
                Operation = Operation.Exit
            };
            sender.Send(req);
        }

        internal Response GetUser(Korisnik user)
        {
            Request req = new Request
            {
                Argument = user,
                Operation = Operation.GetUser
            };
            sender.Send(req);
            Response response = (Response)receiver.Receive();
            return response;
        }
    }
}
