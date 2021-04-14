using App.Application.Contracts.Persistence;
using Domain.App.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories
{
    public class AttachmentContentRepository : BaseRepository<AttachmentContent>, IAttachmentContentRepository
    {
        public AttachmentContentRepository(IDbContextFactory<BuildingDbContext> dbContext) : base(dbContext)
        {

        }
    }
}
