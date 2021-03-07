using Application.App.Services.Lookups;
using Application.App.Services.Projects;
using Microsoft.AspNetCore.Components;
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
        private ILookupServices _lookupServices { get; set; }

        protected async override Task OnInitializedAsync()
        {
            ProjectTypeList = await _lookupServices.GetProjectTypeList();
        }
       

        private void SubmitProject()
        {
            Console.WriteLine("Form Submitted Successfully!");
        }
    }
}
