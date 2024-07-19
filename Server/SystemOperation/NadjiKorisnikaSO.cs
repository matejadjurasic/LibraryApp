using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class NadjiKorisnikaSO : SystemOperationBase
    {
        private readonly Korisnik k;
        public Korisnik Result { get; set; }
        public NadjiKorisnikaSO(Korisnik k)
        {
            this.k = k;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Login(k);
        }
    }
}
