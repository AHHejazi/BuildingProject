using App.Application.Contracts.Persistence;
using Domain.App.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories
{
    public class AttachmentTypeRepository : BaseRepository<AttachmentType>, IAttachmentTypeRepository
    {
        public AttachmentTypeRepository(IDbContextFactory<BuildingDbContext> dbContext) : base(dbContext)
        {

        }
    }
}