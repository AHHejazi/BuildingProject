using System;
using System.Collections.Generic;
using System.Text;
using Domain.App.Entities;
using System.Threading.Tasks;

namespace Application.App.Services.Projects
{
    public interface IProjectService
    {
        Task<Guid> AddProject(ProjectDto project);
        //Task UpdateProject(Project project);
        Task DeleteProjectAsync(Guid projectId);

        Task<IReadOnlyList<Project>> ProjectListQuery();


        Task<Project> GetProjectByIdAsync(Guid Id);
        Task<List<Project>> SearchProjectsAsync(string searchTerm);
        Task UpdateProject(ProjectDto projectDto);
    }
}
