using App.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class AttachmentContentConfiguration : IEntityTypeConfiguration<AttachmentContent>
    {
        public void Configure(EntityTypeBuilder<AttachmentContent> entity)
        {
            entity.ToTable(nameof(AttachmentContent), MappingDefaults.CommonSchema);
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FileContent).IsRequired();

            entity.HasOne(a => a.Attachment)
       .WithOne(b => b.AttachmentContent)
       .HasForeignKey<Attachment>(b => b.Id);
        }
    }
}
