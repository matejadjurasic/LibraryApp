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
        public Bibliotekar Result { get; private set; }
        public NadjiBibliotekaraSO(Bibliotekar b)
        {
            this.b = b;
        }
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAllEntitiesWithCondition(b);
            if (entities != null && entities.Count > 0)
            {
                Result = entities.First() as Bibliotekar;
            }
            else
            {
                Result = null;
            }
        }
    }
}
