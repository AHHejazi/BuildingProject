﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.App.Entities;
using System.Threading.Tasks;
using Framework.Core.ListManagment;
using Application.App.Responses;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.App.Services.Projects
{
    public interface IProjectService
    {
        Task<Guid> AddProject(ProjectDto project);

        Task<BaseResponse> DeleteProjectAsync(Guid projectId);

        Task<IReadOnlyList<Project>> ProjectListQuery();

        Task<ProjectDto> GetProjectByIdAsync(Guid Id);

        Task<ProjectVM> SearchProjectsAsync(ProjectVM projectVM);

        Task UpdateProject(ProjectDto projectDto);

        Task<IEnumerable<SelectListItem>> ProjectListByCurrentUserAsync(string userName=null);

        Task<Guid> AddProjectDiagramAsync(ProjectDiagramsDto model);
    }
}
