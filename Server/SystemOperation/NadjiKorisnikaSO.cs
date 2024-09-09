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
        public Korisnik Result { get; private set; }
        public NadjiKorisnikaSO(Korisnik k)
        {
            this.k = k;
        }
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAllEntitiesWithCondition(k);
            if (entities != null && entities.Count > 0)
            {
                Result = entities.First() as Korisnik;
            }
            else
            {
                Result = null;
            }
        }
    }
}
