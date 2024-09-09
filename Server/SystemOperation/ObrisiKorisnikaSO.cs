using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class ObrisiKorisnikaSO : SystemOperationBase
    {
        private readonly Korisnik korisnik;
        private readonly int korisnikId;
        public bool Result { get; private set; }

        public ObrisiKorisnikaSO(Korisnik korisnik, int korisnikId)
        {
            this.korisnik = korisnik;
            this.korisnikId = korisnikId;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.DeleteEntity(korisnik);
        }
    }
}
