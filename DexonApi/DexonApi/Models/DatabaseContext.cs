using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DexonApi.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Thickness> Thicknesses { get; set; }
        public DbSet<TestPoint> TestPoints { get; set; }
        public DbSet<Cml> Cml { get; set; }
        public DbSet<Info> Info { get; set; }

    }
}
