using Application.App.Services.Projects;
using Domain.App.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Projects
{
    public partial class Details : ComponentBase
    {
        [Inject]
        public IProjectService _projectService { get; set; }
        public Project project;

        [Parameter]
        public Guid Id { get; set; }

       
        protected override async Task OnInitializedAsync()
        {
            project = await _projectService.GetProjectByIdAsync(Id);
        }
    }
}