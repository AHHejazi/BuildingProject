using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories
{
    public class OutbuildingsRepository : BaseRepository<Outbuildings>, IOutbuildingsRepository
    {
        public OutbuildingsRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
