using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamirhane.Data
{
    public class Randevu
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public int AracId { get; set; }
        public DateTime RandevuTarihi { get; set; }
    }
}
