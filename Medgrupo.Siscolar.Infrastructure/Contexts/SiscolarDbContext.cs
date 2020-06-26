using Medgrupo.Siscolar.Domain.Entities;
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
            modelBuilder.Entity<School>().ToTable("School");
            modelBuilder.Entity<School>().Property(x => x.Id);
            modelBuilder.Entity<School>().Property(x => x.Name).HasMaxLength(160).HasColumnType("varchar(255)");
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