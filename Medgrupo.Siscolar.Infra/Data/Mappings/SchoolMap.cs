using System;
using Medgrupo.Siscolar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medgrupo.Siscolar.Infra.Data.Mappings
{
    public class SchoolMap : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("School");
            builder.Property(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(160).HasColumnType("varchar(255)");
            builder.Property(x => x.MaxSchoolClass).IsRequired();
            builder.Property(x => x.MaxSchoolStudents).IsRequired();
            builder.Property(x => x.SchoolPrincipal).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.CreateDate).IsRequired().HasDefaultValueSql("GetDate()");
            builder.Property(x => x.LastUpdateDate).IsRequired();

        }
        
    }
}