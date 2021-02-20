using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pp.Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class SuppliesConfiguration : IEntityTypeConfiguration<Supplies>
    {
        public void Configure(EntityTypeBuilder<Supplies> entity)
        {
            entity.ToTable(nameof(Supplies), MappingDefaults.LookupSchema);
            entity.HasKey(o => o.Id);
            entity.Property(e => e.NameAr).IsRequired();
            entity.Property(e => e.NameEn);

        }
    }
}
