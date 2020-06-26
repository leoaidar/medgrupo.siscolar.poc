using System;
using Medgrupo.Siscolar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medgrupo.Siscolar.Infrastructure.Data.Mappings
{
    public class SchoolMap : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("School");
            builder.Property(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(160).HasColumnType("varchar(255)");
        }
        
    }
}