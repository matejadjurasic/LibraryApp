using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class KnjigaPisac
    {
        public Knjiga Knjiga { get; set; }
        public Pisac Pisac { get; set; }
    }
}
