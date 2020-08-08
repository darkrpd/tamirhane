using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamirhane.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=TamirhaneConnectionString")
        {

        }

        public DbSet<Arac> Aracs { get; set; }
        public DbSet<IsEmri> IsEmris { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Randevu> Randevus { get; set; }
         
    }
}