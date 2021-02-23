
using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    public class OutbuildingsRepository : BaseRepository<Outbuildings>, IOutbuildingsRepository
    {
        public OutbuildingsRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
