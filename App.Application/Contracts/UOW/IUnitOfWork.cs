﻿using App.Application.Contracts.Persistence;
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
        IAttachmentRepository Attachments { get; }

        IAttachmentContentRepository AttachmentContents { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
