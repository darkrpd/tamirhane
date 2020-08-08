using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamirhane.Data
{
    public class Musteri
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public ICollection<Arac> Aracs { get; set; }
    }
}
