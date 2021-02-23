using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Repositories
{
    public class IncomesRepository : BaseRepository<Incomes>, IIncomesRepository
    {
        public IncomesRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
