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
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FileContent).IsRequired();
            //entity.Property(e => e.CreatedOn).IsRequired();
            //entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            //entity.Property(e => e.UpdatedBy).HasMaxLength(250);
            // to check entity.Property(e => e.AttachmentId).IsRequired();
            // to check for relation
        }
    }
}
