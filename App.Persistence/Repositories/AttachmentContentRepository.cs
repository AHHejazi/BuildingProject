using App.Application.Contracts.Persistence;
using Domain.App.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    public class AttachmentContentRepository : BaseRepository<AttachmentContent>, IAttachmentContentRepository
    {
        public AttachmentContentRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
