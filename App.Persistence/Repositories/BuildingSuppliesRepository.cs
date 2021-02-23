using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    public class BuildingSuppliesRepository : BaseRepository<BuildingSupplies>, IBuildingSuppliesRepository
    {
        public BuildingSuppliesRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
