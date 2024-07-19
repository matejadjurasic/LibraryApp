using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class NadjiBibliotekaraSO : SystemOperationBase
    {
        private readonly Bibliotekar b;
        public Bibliotekar Result { get; set; }
        public NadjiBibliotekaraSO(Bibliotekar b)
        {
            this.b = b;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.LoginB(b);
        }
    }
}
