using App.Application.Contracts.Persistence;
using Domain.App.Entities.Lookup;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories
{
    public class OutbuildingsTypeRepository : BaseRepository<OutbuildingsType>, IOutbuildingsTypeRepository
    {
        public OutbuildingsTypeRepository(IDbContextFactory<BuildingDbContext> dbContext) : base(dbContext)
        {

        }
    }
}
