using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configurations
{
    public class BuildingSuppliesConfiguration : IEntityTypeConfiguration<BuildingSupplies>
    {
        public void Configure(EntityTypeBuilder<BuildingSupplies> entity)
        {
            entity.HasKey(o => o.Id);
            entity.Property(t => t.Payment).IsRequired();
            entity.Property(e => e.BuildingId).IsRequired();
            entity.Property(e => e.SuppliesId).IsRequired();
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(e => e.UpdatedBy).HasMaxLength(250);


            //modelBuilder.Entity<Student>()
            //    .HasMany<Course>(s => s.Courses)
            //    .WithMany(c => c.Students)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("StudentRefId");
            //        cs.MapRightKey("CourseRefId");
            //        cs.ToTable("StudentCourse");
            //    });
            

        }
    }
}
