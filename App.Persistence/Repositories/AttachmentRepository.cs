using App.Application.Contracts.Persistence;
// why there is a choice to use .net.mail
using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository()
        {

        }
    }
}
