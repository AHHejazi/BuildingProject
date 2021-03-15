using Application.App.Services.Buildings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Buildings
{
    public partial class Details: ComponentBase
    {
        [Inject]
        public IBuildingService _buildingService { get; set; }
        public BuildingDto buildingDto;


        [Parameter]
        public Guid Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            buildingDto = await _buildingService.GetBuildingByIdAsync(Id);
        }
    }
}
