using App.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class AttachmentTypeConfiguration : IEntityTypeConfiguration<AttachmentType>
    {
        public void Configure(EntityTypeBuilder<AttachmentType> entity)
        {
            //to ask about entity.HasKey(e => e.Id);
            entity.Property(e => e.NameAr).IsRequired();
            entity.Property(e => e.NameEn).IsRequired();
            entity.Property(e => e.Code).IsRequired();
            entity.Property(e => e.ImageMaxHeight).IsRequired();
            entity.Property(e => e.ImageMaxWidth).IsRequired();
            entity.Property(e => e.IsImage).IsRequired();
            entity.Property(e => e.IsMandatory).IsRequired();
            entity.Property(e => e.MaxSizeInMegabytes).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);
            // to check entity.Property(e => e.AttachmentId).IsRequired();

            //to check 
            //entity.HasOne(d => d.Attachment)
            //   .WithMany(p => p.Attachments)
            //   .HasForeignKey(d => d.AttachmentId);
        }
    }
}
