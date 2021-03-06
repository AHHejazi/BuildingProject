
using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(BuildingDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> IsProjectNameUnique(string nameAr, string nameEn)
        {
           return true ;
        }
    }
}
