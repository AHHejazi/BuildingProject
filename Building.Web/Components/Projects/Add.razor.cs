using Application.App.Services.Lookups;
using Application.App.Services.Projects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Building.Web.Components.Projects
{
    public partial class Add : ComponentBase
    {
        public ProjectDto Model = new ProjectDto();
        private IEnumerable<SelectListItem> ProjectTypeList;

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Inject]
        private IProjectService _projectService { get; set; }

        [Inject]
        private ILookupServices _lookupServices { get; set; }

        private EditContext editContext;

        protected async override Task OnInitializedAsync()
        {
            ProjectTypeList = await _lookupServices.GetProjectTypeList();
            editContext = new EditContext(Model);
        }


        private void SubmitProject()
        {
            var isValid = editContext.Validate();

            if (isValid)
            {
                var retObjid = _projectService.AddProject(Model);
            }
            else
            {

            }


        }
    }
}
