
using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository()
        {

        }

        public Task<bool> IsProjectNameUnique(string nameAr, string nameEn)
        {
            throw new NotImplementedException();
        }
    }
}
