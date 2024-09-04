using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class SacuvajPotvrduSO : SystemOperationBase
    {
        private readonly Potvrda potvrda;
        public bool Result { get; private set; }

        public SacuvajPotvrduSO(Potvrda potvrda)
        {
            this.potvrda = potvrda;
        }

        protected override void ExecuteConcreteOperation()
        {
            int potvrdaId = broker.AddEntity(potvrda);
            if (potvrdaId > 0)
            {
                foreach(StavkaPotvrde stavka in potvrda.Stavke)
                {
                    stavka.Potvrda.PotvrdaId = potvrdaId;
                    stavka.Knjiga.BrojDostupnihKopija -= stavka.Kolicina;
                    broker.UpdateEntity(stavka.Knjiga, stavka.Knjiga.KnjigaId);
                    broker.AddEntity(stavka);
                }
                Result = true;
            }
            else
            {
                Result = false;
            }
        }
    }
}
