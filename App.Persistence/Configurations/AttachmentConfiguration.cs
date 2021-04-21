using Domain.App.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> entity)
        {
            entity.ToTable(nameof(Attachment), MappingDefaults.CommonSchema);
            entity.HasKey(e => e.Id);
        entity.Property(e => e.FileName).IsRequired();
        entity.Property(e => e.Extension).IsRequired();
        entity.Property(e => e.FilePath).IsRequired(false);
        entity.Property(e => e.ContentType).IsRequired();
        entity.Property(e => e.TitleAr).IsRequired(false);
        entity.Property(e => e.TitleEn).IsRequired(false);
        entity.Property(e => e.DescriptionAr).IsRequired(false);
        entity.Property(e => e.DescriptionEn).IsRequired(false);
        entity.Property(e => e.AttachmentTypeId).IsRequired();
        entity.Property(e => e.Thumbnail).IsRequired();
        entity.Property(e => e.CreatedOn).IsRequired();
        entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
        entity.Property(e => e.UpdatedBy).HasMaxLength(250);

        }
    }
}
