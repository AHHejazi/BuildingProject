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
    public partial class Edit : ComponentBase
    {
        [Inject]
            public IBuildingService _buildingService { get; set; }
            public BuildingDto buildingDto;
            private IEnumerable<SelectListItem> BuildingTypeList;

            [Inject]
            private ILookupServices _lookupServices { get; set; }

            [Parameter]
            public Guid Id { get; set; }


            protected async override Task OnInitializedAsync()
            {
            buildingDto = await _buildingService.GetBuildingByIdAsync(Id);
            BuildingTypeList = await _lookupServices.GetBuildingTypeList();
            }

            public void ValidFormSubmitted()
            {
            _buildingService.UpdateBuilding(buildingDto);
            }
        }
    }

