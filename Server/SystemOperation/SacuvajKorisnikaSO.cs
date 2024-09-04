using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class SacuvajKorisnikaSO : SystemOperationBase
    {
        private readonly Korisnik korisnik;
        public bool Result { get; private set; }

        public SacuvajKorisnikaSO(Korisnik korisnik)
        {
            this.korisnik = korisnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            if(broker.AddEntity(korisnik) > 0)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }
            //Result = broker.AddEntity(korisnik);
        }
    }
}
