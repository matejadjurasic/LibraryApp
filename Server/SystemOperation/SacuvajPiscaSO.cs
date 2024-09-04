using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    internal class SacuvajPiscaSO : SystemOperationBase
    {
        private readonly Pisac pisac;
        public bool Result { get; private set; }

        public SacuvajPiscaSO(Pisac pisac)
        {
            this.pisac = pisac;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (broker.AddEntity(pisac) > 0)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }
        }
    }
}
