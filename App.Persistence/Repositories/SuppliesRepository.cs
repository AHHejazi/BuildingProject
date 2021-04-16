using App.Application.Contracts.Persistence;
using Domain.App.Entities.Lookup;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories
{
    public class SuppliesRepository : BaseRepository<Supplies>, ISuppliesRepository
    {
        public SuppliesRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
