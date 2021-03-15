using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> IsBuildingNameUnique(string Number)
        {
            return true;
        }
    }
}
