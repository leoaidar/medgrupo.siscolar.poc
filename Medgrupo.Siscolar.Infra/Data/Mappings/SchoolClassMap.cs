using System;
using Medgrupo.Siscolar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medgrupo.Siscolar.Infra.Data.Mappings
{
    public class SchoolClassMap : IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            builder.ToTable("SchoolClassClass");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(160).HasColumnType("varchar(255)");
            builder.Property(x => x.SchoolClassCode).IsRequired().HasMaxLength(10).HasColumnType("varchar(10)");
            builder.Property(x => x.SchoolYear).IsRequired().HasMaxLength(4);
            builder.Property(x => x.Shift).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.CreateDate).IsRequired().HasDefaultValueSql("GetDate()");
            builder.Property(x => x.LastUpdateDate).IsRequired();
        }
        
    }
}