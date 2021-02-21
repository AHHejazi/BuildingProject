using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{

    public class IncomesConfiguration : IEntityTypeConfiguration<Incomes>
    {
        public void Configure(EntityTypeBuilder<Incomes> entity)
        {
            entity.ToTable(nameof(Incomes), MappingDefaults.BuildingSchema);
            entity.HasKey(o => o.Id);
            entity.Property(t => t.BuildingId).IsRequired();
            entity.Property(e => e.Amount).IsRequired();
            entity.Property(e => e.ShareHolderId).IsRequired();
            entity.Property(e => e.IncomeDate).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);

           // to ask for relations 

        }
    }
}
