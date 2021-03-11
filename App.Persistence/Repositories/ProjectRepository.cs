
using Application.App.Contracts.Persistence;
using Application.App.Services.Projects;
using Domain.App.Entities;
using Microsoft.EntityFrameworkCore;
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

        public Task UpdateAsync(ProjectDto project)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectVM> SearchAsync(ProjectVM projectVM)
        {

            //var filters = new List<Expression<Func<Project, bool>>>();

            //if (!string.IsNullOrEmpty(projectVM.NameAr))
            //{
            //    Expression<Func<Project, bool>> nameArFilter = u => u.NameAr.Contains(projectVM.NameAr);
            //    filters.Add(nameArFilter);
            //}

            //if (!string.IsNullOrEmpty(projectVM.NameEn))
            //{
            //    Expression<Func<Project, bool>> nameEnFilter = u => u.NameEn.Contains(projectVM.NameEn);
            //    filters.Add(nameEnFilter);
            //}

            var project = await _dbContext.Projects.Where(s => (string.IsNullOrEmpty(projectVM.NameAr) || s.NameAr.ToLower().Contains(projectVM.NameAr.ToLower()))

            && (string.IsNullOrEmpty(projectVM.NameEn) || s.NameEn.ToLower().Contains(projectVM.NameEn.ToLower()))
            && (s.IsActive.Equals(projectVM.IsActive))

            ).ToListAsync();

            projectVM.ProjectList = project;
            return projectVM;
        }
        

    }
}
