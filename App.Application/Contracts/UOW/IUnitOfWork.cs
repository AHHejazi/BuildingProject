using App.Application.Contracts.Persistence;
using Application.App.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.App.Contracts.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository Projects { get; }
        ISuppliesRepository Suppliess { get; }
        IComponentRepository Components { get;}
        IAttachmentRepository Attachments { get; }

        IOutbuildingsTypeRepository OutbuildingType { get; }

        IAttachmentContentRepository AttachmentContents { get; }

        IBuildingRepository Buildings { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
