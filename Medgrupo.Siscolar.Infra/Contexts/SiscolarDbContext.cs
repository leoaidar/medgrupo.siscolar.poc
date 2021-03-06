﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Medgrupo.Siscolar.Domain.Entities;
using Medgrupo.Siscolar.Infra.Data.Mappings;
using Medgrupo.Siscolar.Infra.Data.Seeds;

namespace Medgrupo.Siscolar.Infra.Contexts
{
    public class SiscolarDbContext : DbContext
    {

        public SiscolarDbContext(DbContextOptions options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchoolMap());
            var schoolSeed = SchoolSeedData.Seed();
            modelBuilder.Entity<School>().HasData(schoolSeed);
            modelBuilder.ApplyConfiguration(new SchoolClassMap());
            modelBuilder.Entity<SchoolClass>().HasData(SchoolClassSeedData.Seed(schoolSeed));
        }        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=BankingDB;User ID=SA;Password=Mudar@4321;MultipleActiveResultSets=true;");
        //    }
        //}

        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
    }
}
