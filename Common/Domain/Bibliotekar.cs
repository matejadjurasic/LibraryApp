using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Bibliotekar
    {
        public int BibliotekarId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}
