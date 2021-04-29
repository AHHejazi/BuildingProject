using Application.App.Services.Lookups;
using Application.App.Services.Projects;
using Domain.App.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Components.Forms;
using GeneralIdentity.App.Code;

namespace Building.Web.Components.Projects
{
    public partial class Edit : PageBase
    {
        [Inject]
        public IProjectService _projectService { get; set; }

        public ProjectDto project;
        private IEnumerable<SelectListItem> ProjectTypeList;

        [Inject]
        private ILookupServices _lookupServices { get; set; }

        [Parameter]
        public Guid Id { get; set; }


        protected async override Task OnInitializedAsync()
        {
            project = await _projectService.GetProjectByIdAsync(Id);
            ProjectTypeList = await _lookupServices.GetProjectTypeList();
        }

        public void SubmitprojectAsync()
        {
            _projectService.UpdateProject(project);
        }
    }
}
