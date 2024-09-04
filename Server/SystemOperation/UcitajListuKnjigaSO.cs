using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class UcitajListuKnjigaSO : SystemOperationBase
    {
        public List<Knjiga> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAllEntities(new Knjiga());
            Result = entities.Cast<Knjiga>().ToList();
        }
    }
}
