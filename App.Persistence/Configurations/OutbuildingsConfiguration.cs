using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{

    public class OutbuildingsConfiguration : IEntityTypeConfiguration<Outbuildings>
    {
        public void Configure(EntityTypeBuilder<Outbuildings> entity)
        {
            entity.ToTable(nameof(Outbuildings), MappingDefaults.BuildingSchema);
            entity.HasKey(o => o.Id);
            entity.Property(t => t.BuildingId).IsRequired();
            entity.Property(e => e.TotalSurfaceArea).IsRequired();
            entity.Property(e => e.OutbuildingsTypeId).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);

        }
    }
}
