using Domain.App.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class SuppliesConfiguration : IEntityTypeConfiguration<Supplement>
    {
        public void Configure(EntityTypeBuilder<Supplement> entity)
        {
            entity.ToTable(nameof(Supplement), MappingDefaults.LookupSchema);
            entity.HasKey(o => o.Id);
            entity.Property(e => e.NameAr).IsRequired();
            entity.Property(e => e.NameEn);

        }
    }
}
