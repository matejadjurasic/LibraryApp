using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain { 

    [Serializable]
    public class Knjiga : IEntity
    {
        public int KnjigaId { get; set; }
        public string Ime { get; set; }
        public int BrojKopija { get; set; }
        public int BrojDostupnihKopija { get; set; }

        public string TableName => "Knjiga";

        public string Values => $"'{Ime}',{BrojKopija},{BrojDostupnihKopija}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
