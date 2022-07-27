using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class L0DbContext : DbContext
    {
        public L0DbContext(DbContextOptions<L0DbContext> options)
         : base(options)
        {

        }
        public DbSet<Urun> Urunler { get; set; }
    }
}
