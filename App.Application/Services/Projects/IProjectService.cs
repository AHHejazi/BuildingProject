using System;
using System.Collections.Generic;
using System.Text;
using Domain.App.Entities;
using System.Threading.Tasks;
using Framework.Core.ListManagment;

namespace Application.App.Services.Projects
{
    public interface IProjectService
    {
        Task<Guid> AddProject(ProjectDto project);
        //Task UpdateProject(Project project);
        Task DeleteProjectAsync(Guid projectId);

        Task<IReadOnlyList<Project>> ProjectListQuery();


        Task<ProjectDto> GetProjectByIdAsync(Guid Id);
        Task<ProjectVM> SearchProjectsAsync(ProjectVM projectVM);
        Task UpdateProject(ProjectDto projectDto);
    }
}
