
using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class ApartmentRepository : BaseRepository<Project>, IApartmentRepository
    {
        public ApartmentRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }
        
    }
}
