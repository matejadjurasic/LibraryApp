﻿using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Controller
    {
        private Broker broker;

        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();
                return instance;
            }
        }
        private Controller() { broker = new Broker(); }
        
        public Korisnik Login(Korisnik user)
        {
            //LoginSO so = new LoginSO(user);
            //so.ExecuteTemplate();
            //return so.Result;
            return null;

        }
        
    }
}
