using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class StavkaPotvrde
    {
        public int StavkaId { get; set; }
        public int Kolicina {  get; set; }
        public Knjiga Knjiga { get; set; }
        public Potvrda Potvrda { get; set; } 
    }
}
