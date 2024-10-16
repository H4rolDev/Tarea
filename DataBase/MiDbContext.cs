using DataBase.Table;
using DataBase.Seeds;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class MiDbContext : DbContext
    {
        public MiDbContext(
            DbContextOptions<MiDbContext> opts
        ) : base(opts)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedPersonas();
        }
        public DbSet<PersonaTable> Personas { get; set; }
    }
}
