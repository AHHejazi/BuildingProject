using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories
{
    public class BuildingSuppliesRepository : BaseRepository<BuildingSupplies>, IBuildingSuppliesRepository
    {
        public BuildingSuppliesRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
