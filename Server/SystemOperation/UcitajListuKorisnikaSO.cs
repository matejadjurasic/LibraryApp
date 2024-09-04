using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public class UcitajListuKorisnikaSO : SystemOperationBase
    {
        public List<Korisnik> Result { get; private set; }
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> entities = broker.GetAllEntities(new Korisnik());
            Result = entities.Cast<Korisnik>().ToList();
        }
    }
}
