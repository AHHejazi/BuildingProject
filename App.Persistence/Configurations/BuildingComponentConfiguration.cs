using Domain.App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class BuildingComponentConfiguration : IEntityTypeConfiguration<BuildingComponent>
    {
        public void Configure(EntityTypeBuilder<BuildingComponent> entity)
        {


            
            entity.Property(e => e.BuildingId).IsRequired();
            entity.Property(e => e.ComponentId).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);

            entity.HasKey(bc => new { bc.BuildingId, bc.ComponentId });

            entity.HasOne(d => d.Building)
             .WithMany(p => p.BuildingComponents)
             .HasForeignKey(d => d.BuildingId);

            entity.HasOne(d => d.Component)
                .WithMany(p => p.BuildingComponents)
                .HasForeignKey(d => d.ComponentId);
        }
    }
}
