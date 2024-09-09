using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class UcitajListuStavkiSO : SystemOperationBase
    {
        private readonly int potvrdaId;
        public List<StavkaPotvrde> Result { get; private set; }

        public UcitajListuStavkiSO(int potvrdaId)
        {
            this.potvrdaId = potvrdaId;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAllEntitiesWithCondition(new StavkaPotvrde(),potvrdaId);
            Result = entities.Cast<StavkaPotvrde>().ToList();
        }
    }
}
