using Medgrupo.Siscolar.Domain.Entities;
using Medgrupo.Siscolar.Infrastructure.Data.Mappings;
using Medgrupo.Siscolar.Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Medgrupo.Siscolar.Infrastructure.Contexts
{
    public class SiscolarDbContext : DbContext
    {
        public SiscolarDbContext(DbContextOptions<SiscolarDbContext> options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchoolMap());
            modelBuilder.Entity<School>().HasData(SchoolSeedData.Seed());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
           {
               optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SiscolarDB;User ID=SA;Password=Mudar@4321;MultipleActiveResultSets=true;");
           }
        }
    }
}