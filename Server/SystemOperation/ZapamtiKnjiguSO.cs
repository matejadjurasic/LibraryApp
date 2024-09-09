using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class ZapamtiKnjiguSO : SystemOperationBase
    {
        private readonly Knjiga knjiga;
        private readonly int knjigaId;
        public bool Result { get; private set; }

        public ZapamtiKnjiguSO(Knjiga knjiga, int knjigaId)
        {
            this.knjiga = knjiga;
            this.knjigaId = knjigaId;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.UpdateEntity(knjiga);
            broker.DeleteEntity(new KnjigaPisac { Knjiga = knjiga });
            foreach (var pisac in knjiga.Pisci)
            {
                KnjigaPisac kp = new KnjigaPisac
                {
                    Knjiga = knjiga,
                    Pisac = pisac
                };

                broker.AddEntity(kp);
            }
            Result = true;
        }
    }
}
