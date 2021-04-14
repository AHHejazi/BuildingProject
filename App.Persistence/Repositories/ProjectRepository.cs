
using Application.App.Contracts.Persistence;
using Application.App.Services.Projects;
using Domain.App.Entities;
using Framework.Core.Globalization;
using Framework.Core.ListManagment;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {

        public ProjectRepository(IDbContextFactory<BuildingDbContext> dbContext) : base(dbContext)
        {
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

        public async Task<IEnumerable<SelectListItem>> ProjectListByCurrentUserAsync(string userName)
        {
            //TODO you have to remove userName when u can get the userName correctly
            return await _dbContext.Projects.Where(c=>c.CreatedBy == userName || string.IsNullOrEmpty(userName))
            .Select(s =>
                 new SelectListItem(
                    CultureHelper.IsArabic ? s.NameAr : s.NameEn, s.Id.ToString())).ToListAsync();
        }
    }
}
