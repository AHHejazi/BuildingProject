using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
    }
}
