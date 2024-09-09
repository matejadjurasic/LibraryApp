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
        private readonly Korisnik user;
        public Korisnik Result { get; private set; }

        public UcitajKorisnikaSO(Korisnik user)
        {
            this.user = user;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = (Korisnik)broker.GetEntity(user);
        }
    }
}
