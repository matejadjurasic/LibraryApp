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
        private readonly Knjiga book;
        public Knjiga Result { get; private set; }

        public UcitajKnjiguSO(Knjiga book)
        {
            this.book = book;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = (Knjiga)broker.GetEntity(book);
            List < IEntity > entities = broker.GetAllEntitiesWithCondition(new Pisac(),book.KnjigaId);
            Result.Pisci = entities.Cast<Pisac>().ToList();
        }
    }
}
