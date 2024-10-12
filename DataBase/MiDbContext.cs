using DataBase;
using DataBase.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class MiDbContext: DbContext
    {
        public MiDbContext(DbContextOptions<MiDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ModelBuilder.Seed();
        }
        public DbSet<Persona> personas {get;set;}
    }
}
