using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Pisac : IEntity
    {
        public int PisacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string TableName => "Pisac";

        public string Values => $"'{Ime}','{Prezime}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
