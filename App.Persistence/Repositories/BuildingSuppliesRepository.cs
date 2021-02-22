using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
   public class BuildingSuppliesRepository : BaseRepository<BuildingSupplies>, IBuildingSuppliesRepository
    {
            public BuildingSuppliesRepository()
            {

            }
    }
}
