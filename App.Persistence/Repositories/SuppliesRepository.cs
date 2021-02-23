using App.Application.Contracts.Persistence;
using pp.Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    public class SuppliesRepository : BaseRepository<Supplies>, ISuppliesRepository
    {
        public SuppliesRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
