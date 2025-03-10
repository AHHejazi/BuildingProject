﻿using Application.App.Services.Projects;
using Domain.App.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.App.Contracts.Persistence
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
        Task<bool> IsProjectNameUnique(string nameAr, string nameEn);
        Task UpdateAsync(ProjectDto project);
        Task<ProjectVM> SearchAsync(ProjectVM projectVM);
        Task<IEnumerable<SelectListItem>> ProjectListByCurrentUserAsync(string userName);
    }
}
