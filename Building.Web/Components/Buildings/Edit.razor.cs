using Application.App.Services.Buildings;
using Application.App.Services.Lookups;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Building.Web.Components.Buildings
{
    public partial class Edit : PageBase
    {
        //public BuildingDto buildingDto;
        public BuildingDto buildingDto = new BuildingDto();

        private EditContext editContext;
        [Inject]
        public IBuildingService _buildingService { get; set; }

        [Parameter]
        public EventCallback<BuildingDto> OnValidSubmit { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        protected async override Task OnParametersSetAsync()
        {
            
            buildingDto = await _buildingService.GetBuildingByIdAsync(Id);
            editContext = new EditContext(buildingDto);
        }
        
        private async Task SubmitBuildingAsync()
        {
            
            var isValid = editContext.Validate();

            if (isValid)
            {
                await _buildingService.UpdateBuilding(buildingDto);
                StatusClass = "alert alert-success";
                Message = "Building updated successfully.";
            }
            else
            {
                StatusClass = "alert alert-danger";
                Message = "Something went wrong while updating building . Please try again.";
            }
        }

        public async Task ValidateForm(EditContext editContext)
        {

            var isValid = editContext.Validate();

            if (!isValid)
                return;

        }
    }
}

