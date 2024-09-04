using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class NadjiKorisnikeSO : SystemOperationBase
    {
        private readonly string searchValue;
        public List<Korisnik> Result { get; private set; }

        public NadjiKorisnikeSO(string serchValue)
        {
            this.searchValue = serchValue;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.SearchEntities(new Korisnik(), searchValue);
            Result = entities.Cast<Korisnik>().ToList();
        }
    }
}
