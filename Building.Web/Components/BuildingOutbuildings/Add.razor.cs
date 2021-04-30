using Application.App.Services.Buildings;
using Application.App.Services.Components;
using Application.App.Services.Lookups;
using Application.App.Services.Outbuildings;
using Domain.App.Entities;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.BuildingOutbuildings
{
    public partial class Add : PageBase
    {
        [Inject]
        private ILookupServices _lookupServices { get; set; }

        private IEnumerable<SelectListItem> ComponentList;
        private IEnumerable<SelectListItem> OutbuildingList;
        private IEnumerable<SelectListItem> buildingList;
        public BuildingOut Model { get; set; } = new();


        protected async override Task OnInitializedAsync()
        {
            buildingList = await _lookupServices.GetBuildingList();

            ComponentList = await _lookupServices.GetComponentList();

            OutbuildingList = await _lookupServices.GetOutbuildingTypeList();
        }

        private async Task SubmitBuildingOutbuildingsAsync()
        {
            try
            {
               // await _componentService.AddBuildingOutbuildings(Model);
                StatusClass = "alert alert-success";
                Message = "New Building Outbuilding added successfully.";
            }
            catch (Exception)
            {

                StatusClass = "alert alert-danger";
                Message = "Something went wrong adding the new Building Outbuilding. Please try again.";

            }

        }
    }
}