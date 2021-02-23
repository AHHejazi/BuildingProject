using App.Application.Contracts.Persistence;
using Domain.App.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
   public class AttachmentTypeRepository : BaseRepository<AttachmentType>, IAttachmentTypeRepository
    {
        public AttachmentTypeRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}