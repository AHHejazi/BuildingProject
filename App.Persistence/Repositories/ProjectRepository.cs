
using Application.App.Contracts.Persistence;
using Application.App.Services.Projects;
using Domain.App.Entities;
using Framework.Core.ListManagment;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private new readonly BuildingDbContext _dbContext;

        public ProjectRepository(BuildingDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> IsProjectNameUnique(string nameAr, string nameEn)
        {
          return await _dbContext.Projects.AnyAsync(x => x.NameAr == nameAr || x.NameEn == nameEn);
        }

        public Task UpdateAsync(ProjectDto project)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectVM> SearchAsync(ProjectVM projectVM)
        {

            var filters = new Filters<Project>();

            filters.Add(!string.IsNullOrEmpty(projectVM.NameAr), u => u.NameAr.Contains(projectVM.NameAr));
            filters.Add(!string.IsNullOrEmpty(projectVM.NameEn), u => u.NameEn.Contains(projectVM.NameEn));
           
            var result = await _dbContext.Projects.AsNoTracking().Paginate(projectVM.PageNumber, projectVM.PageSize, filters);

            projectVM.Items =
               new StaticPagedList<Project>(
                   result.Results,
                   result.CurrentPage,
                   result.PageSize,
                   result.RecordCount);

            return projectVM;
        }


    }
}
