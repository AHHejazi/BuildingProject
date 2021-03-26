
using Application.App.Contracts;
using Domain.App.Common;
using Domain.App.Entities;
using Domain.App.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Persistence
{
    public class BuildingDbContext: DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public BuildingDbContext(DbContextOptions<BuildingDbContext> options)
           : base(options)
        {
        }

        public BuildingDbContext(DbContextOptions<BuildingDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<AttachmentContent> AttachmentContents { get; set; }
        public DbSet<AttachmentType> AttachmentTypes { get; set; }
        public DbSet<OutbuildingsType> OutbuildingsTypes { get; set; }
        public DbSet<Supplies> Suppliess { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingSupplies> BuildingSupplies { get; set; }
        public DbSet<Incomes> Incomes { get; set; }
        public DbSet<Outbuildings> Outbuildings { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuildingDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId??"ahejazi";
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedOn = DateTime.Now;
                        entry.Entity.UpdatedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
