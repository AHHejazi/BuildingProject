using Domain.App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class BuildingOutConfiguration : IEntityTypeConfiguration<BuildingOut>
    { 
        public void Configure(EntityTypeBuilder<BuildingOut> entity)
            {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.BuildingId).IsRequired();
            entity.Property(e => e.ComponentId).IsRequired();
            entity.Property(e => e.OutbuildingsTypeId).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);

            entity.HasKey(bc => new { bc.BuildingId, bc.ComponentId, bc.OutbuildingsTypeId });

                entity.HasOne(d => d.Building)
                 .WithMany(p => p.BuildingOuts)
                 .HasForeignKey(d => d.BuildingId);

                //entity.HasOne(d => d.Component)
                //    .WithMany(p => p.BuildingOuts)
                //    .HasForeignKey(d => d.ComponentId);
                
                //entity.HasOne(d => d.OutbuildingsType)
                //.WithMany(p => p.BuildingOuts)
                //.HasForeignKey(d => d.OutbuildingsTypeId);
        }
        }
    }
