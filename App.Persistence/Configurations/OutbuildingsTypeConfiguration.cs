using App.Domain.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class OutbuildingsTypeConfiguration : IEntityTypeConfiguration<OutbuildingsType>
    {
        public void Configure(EntityTypeBuilder<OutbuildingsType> entity)
        {
            entity.HasKey(o => o.Id);
   
            entity.Property(e => e.NameAr).IsRequired();
            entity.Property(e => e.NameEn);
        }
    }
}
