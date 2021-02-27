using Domain.App.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class ProjectTypeConfiguration : IEntityTypeConfiguration<ProjectType>
    {
        public void Configure(EntityTypeBuilder<ProjectType> entity)
        {
            entity.ToTable(nameof(ProjectType), MappingDefaults.LookupSchema);
            entity.HasKey(o => o.Id);
   
            entity.Property(e => e.NameAr).IsRequired();
            entity.Property(e => e.NameEn);

            
        }
    }
}
