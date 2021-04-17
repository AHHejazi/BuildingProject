using App.Application.Contracts.Persistence;
using App.Persistence.Repositories;
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
        public UnitOfWork(BuildingDbContext contextFactory)
        {
            _context = contextFactory;
            Projects = new ProjectRepository(_context);
            Buildings = new BuildingRepository(_context);
            Attachments = new AttachmentRepository(_context);
            AttachmentContents = new AttachmentContentRepository(_context);
        }

        public IAttachmentContentRepository AttachmentContents { get; private set; }
        public IAttachmentRepository Attachments { get; private set; }
        public IProjectRepository Projects { get; private set; }

        public IBuildingRepository Buildings { get; private set; }


        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {


            foreach (var entry in _context.ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.CreatedBy = "ahejazi";//_loggedInUserService.UserId??"ahejazi";
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedOn = DateTime.Now;
                        entry.Entity.UpdatedBy = "ahejazi";
                        break;
                }
            }
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
