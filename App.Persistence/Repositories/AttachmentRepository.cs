using App.Application.Contracts.Persistence;
// why there is a choice to use .net.mail
using Domain.App.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
