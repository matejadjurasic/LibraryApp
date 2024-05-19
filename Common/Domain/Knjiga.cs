using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain { 

    [Serializable]
    public class Knjiga
    {
        public int KnjigaId { get; set; }
        public string Ime { get; set; }
        public int BrojKopija { get; set; }
        public int BrojDostupnihKopija { get; set; }
    }
}
