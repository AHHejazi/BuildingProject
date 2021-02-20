using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pp.Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class BuildingSuppliesConfiguration : IEntityTypeConfiguration<BuildingSupplies>
    {
        public void Configure(EntityTypeBuilder<BuildingSupplies> entity)
        {


            entity.Property(t => t.Payment).IsRequired();
            entity.Property(e => e.BuildingId).IsRequired();
            entity.Property(e => e.SuppliesId).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);

            entity.HasKey(bc => new { bc.BuildingId, bc.SuppliesId });

            entity.HasOne(d => d.Building)
             .WithMany(p => p.BuildingSupplies)
             .HasForeignKey(d => d.BuildingId);

            entity.HasOne(d => d.Supplies)
                .WithMany(p => p.BuildingSupplies)
                .HasForeignKey(d => d.SuppliesId);
        }
    }
}
