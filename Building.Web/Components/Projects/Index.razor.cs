using Application.App.Services.Projects;
using Domain.App.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Projects
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IProjectService _projectService { get; set; }
        public ProjectVM ProjectVM=new ProjectVM();

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        private string searchTerm;

        async Task SearchProjects()
        {
            ProjectVM = await _projectService.SearchProjectsAsync(ProjectVM);
        }

        
        protected override async Task OnInitializedAsync()
        {
            ProjectVM.ProjectList = await _projectService.ProjectListQuery();
        }

        public async Task DeleteProject(Guid projectId)
        {
            await _projectService.DeleteProjectAsync(projectId);
            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }
    }
}
