using App.Application.Contracts.Persistence;
using App.Persistence.Repositories;
using Application.App.Contracts;
using Application.App.Contracts.Persistence;
using Application.App.Contracts.UOW;
using Domain.App.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Persistence.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BuildingDbContext _context;
        private readonly ILoggedInUserService _loggedInUserService;
        public UnitOfWork(BuildingDbContext context, ILoggedInUserService loggedInUserService)
        {
            _context = context;
            Projects = new ProjectRepository(_context);
            Suppliess = new SuppliesRepository(_context);
            Buildings = new BuildingRepository(_context);
            BuildingOuts = new BuildingOutRepository(_context);
            Components = new ComponentRepository(_context);
            OutbuildingType = new OutbuildingsTypeRepository(_context);
            Attachments = new AttachmentRepository(_context);
            AttachmentContents = new AttachmentContentRepository(_context);
            _loggedInUserService = loggedInUserService;
        }

        public IAttachmentContentRepository AttachmentContents { get; private set; }
        public IAttachmentRepository Attachments { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public IOutbuildingsTypeRepository OutbuildingType { get; private set; }
        public IBuildingRepository Buildings { get; private set; }
        public IBuildingOutRepository BuildingOuts { get; private set; }
        public ISuppliesRepository Suppliess { get; private set; }
        public IComponentRepository Components { get; private set; }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {


            foreach (var entry in _context.ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId ?? "ahejazi";
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedOn = DateTime.Now;
                        entry.Entity.UpdatedBy = _loggedInUserService.UserId ?? "ahejazi";
                        break;
                }
            }
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }


     
    }
}
