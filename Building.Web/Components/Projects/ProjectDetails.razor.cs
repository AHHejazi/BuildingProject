using Application.App.Services.Projects;
using Domain.App.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Projects
{
    public partial class ProjectDetails : ComponentBase
    {
        [Inject]
        public IProjectService _projectService { get; set; }
        public IReadOnlyList<Project> projectList;


        protected override void OnInitialized()
        {
            projectList = new List<Project>();
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync()
        {
            projectList = await _projectService.ProjectListQuery();
        }
    }
}