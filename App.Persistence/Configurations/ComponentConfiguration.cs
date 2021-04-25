using Domain.App.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations
{
    public class ComponentConfiguration : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> entity)
        {
            entity.ToTable(nameof(Component), MappingDefaults.LookupSchema);
            entity.HasKey(o => o.Id);
            entity.Property(e => e.NameAr).IsRequired();
            entity.Property(e => e.NameEn);

        }
    }
}
