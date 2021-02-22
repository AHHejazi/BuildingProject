using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
