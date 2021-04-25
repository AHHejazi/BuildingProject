using Application.App.Contracts.Persistence;
using Domain.App.Entities;

namespace App.Persistence.Repositories
{
    public class BuildingComponentRepository : BaseRepository<BuildingComponent>, IBuildingComponentRepository
    {
        public BuildingComponentRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
