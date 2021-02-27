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
        Task UpdateProject(Project project);
        Task DeleteProjectAsync(Project project);

        Task<IReadOnlyList<Project>> ProjectListQuery();


        Task<Project> GetProjectByIdAsync(Guid Id);
    }
}
