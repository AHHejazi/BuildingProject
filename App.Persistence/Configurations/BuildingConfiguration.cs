using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Number).IsRequired().HasMaxLength(15);
            entity.Property(e => e.EstimatedCost).IsRequired();
            entity.Property(e => e.TotalSurfaceArea).IsRequired();
            entity.Property(e => e.NumberOfFloor).IsRequired();
            entity.Property(e => e.LicenseNumber).IsRequired();
            entity.Property(e => e.StampingNumber).IsRequired();
            entity.Property(e => e.NumberOfApartment).IsRequired();
            entity.Property(e => e.Apartments).IsRequired();
            entity.Property(e => e.Outbuildings).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);

            entity.HasOne(d => d.Project)
               .WithMany(p => p.Buildings)
               .HasForeignKey(d => d.ProjectId);

            


        }
    }
}
