using Application.App.Contracts.Persistence;
using Domain.App.Entities;

namespace App.Persistence.Repositories
{
    public class BuildingOutRepository : BaseRepository<BuildingOut>, IBuildingOutRepository
    {
        public BuildingOutRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}


