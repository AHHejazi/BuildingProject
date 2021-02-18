using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.NameAr).IsRequired();
            entity.Property(e => e.NameEn).IsRequired();
            entity.Property(e => e.Number).IsRequired().HasMaxLength(15);
            entity.Property(e => e.ContractorName).IsRequired();
            entity.Property(e => e.QuarterName).IsRequired();
            entity.Property(e => e.PropertyFullAddress).IsRequired();
            entity.Property(e => e.PropertyNumber).IsRequired().HasMaxLength(15); 
            entity.Property(e => e.ConsultingOfficeName).IsRequired();
            entity.Property(e => e.CityName).IsRequired();
            entity.Property(e => e.PropertyLatitude).IsRequired(); 
            entity.Property(e => e.PropertyLongitude).IsRequired();
            entity.Property(e => e.SerialNumber).IsRequired().HasMaxLength(15); 
            entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true); ;
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);

        }
    }
}
