using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class ZapamtiPotvrduSO : SystemOperationBase
    {
        private readonly Potvrda potvrda;

        public bool Result { get; private set; }

        public ZapamtiPotvrduSO(Potvrda potvrda)
        {
            this.potvrda = potvrda;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.UpdateEntity(potvrda);
            foreach (StavkaPotvrde item in potvrda.Stavke)
            {
                item.Knjiga.BrojDostupnihKopija += item.Kolicina;
                broker.UpdateEntity(item.Knjiga);
            }
        }
    }
}
