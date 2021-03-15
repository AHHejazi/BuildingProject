using Application.App.Services.Buildings;
using Application.App.Services.Lookups;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Buildings
{
    public partial class Add : ComponentBase
    {
        public BuildingDto Model = new BuildingDto();
        private IEnumerable<SelectListItem> BuildingTypeList;

        [Inject]
        private NavigationManager _navigationManager { get; set; }


        [Inject]
        private ILookupServices _lookupServices { get; set; }

        protected async override Task OnInitializedAsync()
        {
            BuildingTypeList = await _lookupServices.GetBuildingTypeList();
        }


        private void SubmitBuilding()
        {
            Console.WriteLine("Form Submitted Successfully!");
        }
    }
}
