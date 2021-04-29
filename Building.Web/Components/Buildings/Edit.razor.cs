using Application.App.Services.Buildings;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Threading.Tasks;

namespace Building.Web.Components.Buildings
{
    public partial class Edit : PageBase
    {

        [Inject]
        public IBuildingService _buildingService { get; set; }

        public BuildingDto buildingDto = new BuildingDto();

        [Parameter]
        public EventCallback<BuildingDto> OnValidSubmit { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        protected async override Task OnParametersSetAsync()
        {
            buildingDto = await _buildingService.GetBuildingByIdAsync(Id);
        }
        
        private void SubmitBuildingAsync()
        {
             _buildingService.UpdateBuilding(buildingDto);
        }
    }
}

