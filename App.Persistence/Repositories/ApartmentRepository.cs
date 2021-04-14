
using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Repositories
{
    public class ApartmentRepository : BaseRepository<Project>, IApartmentRepository
    {
        public ApartmentRepository(IDbContextFactory<BuildingDbContext> dbContext) : base(dbContext)
        {

        }
        
    }
}
