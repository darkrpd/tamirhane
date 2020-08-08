using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamirhane.Data
{
    public class Arac
    {
        public int Id { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int ModelYili { get; set; }
        public Musteri Musteri { get; set; }
    }
}
