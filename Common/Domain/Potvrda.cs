using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Potvrda : IEntity
    {
        public int PotvrdaId { get; set; }
        public DateTime DatumOd { get; set; }
        public Korisnik Korisnik { get; set; }
        public Bibliotekar Bibliotekar { get; set; }

        public string TableName => "Potvrda";

        public string Values => $"'{DatumOd.ToString("yyyyMMdd HH:mm")}',{Korisnik.KorisnikId},{Bibliotekar.BibliotekarId}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
