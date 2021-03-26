using Domain.App.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class BuildingTypeConfiguration : IEntityTypeConfiguration<BuildingType>
    {
            public void Configure(EntityTypeBuilder<BuildingType> entity)
            {
                entity.ToTable(nameof(BuildingType), MappingDefaults.LookupSchema);
                entity.HasKey(o => o.Id);

                entity.Property(e => e.Number).IsRequired();


            }
        }
    }