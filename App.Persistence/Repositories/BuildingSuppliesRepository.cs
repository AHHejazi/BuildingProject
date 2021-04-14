using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories
{
    public class BuildingSuppliesRepository : BaseRepository<BuildingSupplies>, IBuildingSuppliesRepository
    {
        public BuildingSuppliesRepository(IDbContextFactory<BuildingDbContext> dbContext) : base(dbContext)
        {

        }
    }
}
