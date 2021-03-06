
using Application.App.Contracts.Persistence;
using Application.App.Services.Projects;
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

        public Task<bool> IsProjectNameUnique(string nameAr, string nameEn)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProjectDto project)
        {
            throw new NotImplementedException();
        }
    }
}
