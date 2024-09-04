using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class UcitajKorisnikaSO : SystemOperationBase
    {
        private readonly int korisnikId;
        public Korisnik Result { get; private set; }

        public UcitajKorisnikaSO(int korisnikId)
        {
            this.korisnikId = korisnikId;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = (Korisnik)broker.GetEntity(new Korisnik(), korisnikId);
        }
    }
}
