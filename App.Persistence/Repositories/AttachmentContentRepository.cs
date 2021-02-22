using App.Application.Contracts.Persistence;
using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    public class AttachmentContentRepository : BaseRepository<AttachmentContent>, IAttachmentContentRepository
    {
        public AttachmentContentRepository()
        {

        }
    }
}
