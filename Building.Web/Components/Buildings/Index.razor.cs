using Application.App.Services.Buildings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Buildings
{
    public partial class Index : ComponentBase
    {
            [Inject]
            public IBuildingService _buildingService { get; set; }
            public BuildingVM BuildingVM = new BuildingVM();

            //used to store state of screen
            protected string Message = string.Empty;
            protected string StatusClass = string.Empty;
            protected bool Saved;

            private string searchTerm;

            async Task SearchBuildings()
            {
            BuildingVM = await _buildingService.SearchBuildingAsync(BuildingVM);
            }


            protected override async Task OnInitializedAsync()
            {
            BuildingVM.BuildingList = await _buildingService.BuildingListQuery();
            }

            public async Task DeleteBuilding(Guid buildingId)
            {
                await _buildingService.DeleteBuildingAsync(buildingId);
                StatusClass = "alert-success";
                Message = "Deleted successfully"; 
                 Saved = true;
            }
        }
    }


