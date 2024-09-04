using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class UcitajListuPisacaSO : SystemOperationBase
    {
        public List<Pisac> Result { get; private set; }
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAllEntities(new Pisac());
            Result = entities.Cast<Pisac>().ToList();
        }
    }
}
