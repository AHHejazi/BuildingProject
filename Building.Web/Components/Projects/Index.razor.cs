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
        public IReadOnlyList<Project> projectList;
        public Project project;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        protected override void OnInitialized()
        {
            projectList = new List<Project>();
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync()
        {
            projectList = await _projectService.ProjectListQuery();
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
