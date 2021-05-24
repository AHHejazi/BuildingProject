using Application.App.Services.BuildingOuts;
using Application.App.Services.Components;
using Application.App.Services.Lookups;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Building.Web.Components.BuildingOutbuildings
{
    public partial class Add : PageBase
    {
        [Inject]
        private ILookupServices _lookupServices { get; set; }

        [Inject]
        private IBuildingOutService _buildingOutService { get; set; }

        private IEnumerable<SelectListItem> ComponentList;

        private IEnumerable<SelectListItem> OutbuildingList;

        private IEnumerable<SelectListItem> buildingList;

        private EditContext editContext;

        private bool isOutBuildingComponent;
        public BuildingOutDto Model { get; set; } = new();
        




        protected async override Task OnInitializedAsync()
        {
            buildingList = await _lookupServices.GetBuildingList();

            ComponentList = await _lookupServices.GetComponentList();

            OutbuildingList = await _lookupServices.GetOutbuildingTypeList();
        }

        private async Task SubmitBuildingOutsAsync()
        {
            try
            {
                await _buildingOutService.AddBuildingOutAsync(Model);
                StatusClass = "alert alert-success";
                Message = "New Building Outbuilding added successfully.";
            }
            catch (Exception)
            {
               
                StatusClass = "alert alert-danger";
                Message = "Something went wrong adding the new Building Outbuilding. Please try again.";

            }

        }
        public async Task ValidateForm(EditContext editContext)
        {

            var isValid = editContext.Validate();

            if (!isValid)
                return;

        }


        public async Task<bool>CheckIsOutBuilding(Guid componentvalue)
        {
            
            //TODO get recored from component table
            var component = await _lookupServices.GetComponentByIdAsync(componentvalue);
            Model.ComponentId = componentvalue;
            //and check the out building value

            // in case true show out building 
            if (component != null)
            {
                isOutBuildingComponent = component.IsOutBuildingType;
            }
            StateHasChanged();
            return isOutBuildingComponent;
        }
    }
}