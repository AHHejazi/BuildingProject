using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories
{
    public class IncomesRepository : BaseRepository<Incomes>, IIncomesRepository
    {
        public IncomesRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
