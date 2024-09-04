using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class NadjiKnjigeSO : SystemOperationBase
    {
        private readonly string searchValue;
        public List<Knjiga> Result { get; private set; }

        public NadjiKnjigeSO(string searchValue)
        {
            this.searchValue = searchValue;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.SearchEntities(new Knjiga(), searchValue);
            Result = entities.Cast<Knjiga>().ToList();
        }
    }
}
