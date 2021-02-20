using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities;
using System.Threading.Tasks;

namespace App.Application.Services.Projects
{
    public interface IProjectService
    {
        Task<Guid> AddProject(ProjectDto project);
        Task UpdateProject(Project project);
        Task DeleteBasketAsync(Project project);

        Task<IReadOnlyList<Project>> ProjectListQuery();
    }
}
