using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class SacuvajKnjiguSO : SystemOperationBase
    {
        private readonly Knjiga knjiga;
        public bool Result { get; private set; }

        public SacuvajKnjiguSO(Knjiga knjiga)
        {
            this.knjiga = knjiga;
        }
        protected override void ExecuteConcreteOperation()
        {
            knjiga.KnjigaId = broker.AddEntity(knjiga);
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
