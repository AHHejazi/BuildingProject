using Domain.App.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    class SystemSettingsConfiguration : IEntityTypeConfiguration<SystemSetting>
    {
        public void Configure(EntityTypeBuilder<SystemSetting> entity)
        {
            entity.ToTable(nameof(SystemSetting), MappingDefaults.CommonSchema);
            entity.HasKey(x=>x.Id);
            entity.Property(e => e.ApplicationId).IsRequired(false);
            entity.Property(e => e.GroupName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Value).IsRequired().HasMaxLength(255);
            entity.Property(e => e.ValueType).IsRequired().HasMaxLength(30).IsUnicode(false);

        }
    }
    
}
