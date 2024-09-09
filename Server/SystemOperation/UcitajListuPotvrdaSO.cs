using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    internal class UcitajListuPotvrdaSO : SystemOperationBase
    {
        public List<Potvrda> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAllEntitiesWithCondition(new Potvrda());
            Result = entities.Cast<Potvrda>().ToList();
        }
    }
}
