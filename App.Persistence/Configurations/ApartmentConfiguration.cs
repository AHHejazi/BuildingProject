using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> entity)
        {
            entity.ToTable(nameof(Apartment), MappingDefaults.BuildingSchema);
            entity.HasKey(o => o.Id);
            entity.Property(t => t.Number).IsRequired().HasMaxLength(15);
            entity.Property(e => e.TotalSurfaceArea).IsRequired();
            // to ask him if I should remove it or keep it
            entity.Property(e => e.Building).IsRequired();
            entity.Property(e => e.BuildingId).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);

            entity.HasOne(d => d.Building)
               .WithMany(p => p.Apartments)
               .HasForeignKey(d => d.BuildingId);



        }
    }
}
