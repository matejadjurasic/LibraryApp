using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class UcitajKnjiguSO : SystemOperationBase
    {
        private readonly int knjigaId;
        public Knjiga Result { get; private set; }

        public UcitajKnjiguSO(int knjigaId)
        {
            this.knjigaId = knjigaId;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (Knjiga)broker.GetEntity(new Knjiga(), knjigaId);
            //Result.Pisci = broker.GetWritersForBook(knjigaId);
            List<IEntity> entities = broker.GetWritersForBook(knjigaId);
            Result.Pisci = entities.Cast<Pisac>().ToList();
        }
    }
}
