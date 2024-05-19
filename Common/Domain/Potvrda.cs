using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Potvrda
    {
        public int PotvrdaId { get; set; }
        public DateTime DatumOd { get; set; }
        public Korisnik Korisnik { get; set; }
        public Bibliotekar Bibliotekar { get; set; }

    }
}
