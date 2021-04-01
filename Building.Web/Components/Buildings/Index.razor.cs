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
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        public IBuildingService _buildingService { get; set; }
        public BuildingVM BuildingVM = new BuildingVM();



        [Parameter]
        public string Page { get; set; } = "1";
        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        protected override async Task OnInitializedAsync()
        {
            await GetBuildings();
        }
        protected async Task SearchBuildings()
        {
            Page = "1";
            BuildingVM.PageNumber = 1;
            BuildingVM = await _buildingService.SearchBuildingsAsync(BuildingVM);
            _navigationManager.NavigateTo("/Building/index/" + Page);
            StateHasChanged();
        }



        protected async Task GetBuildings()
        {
            BuildingVM = await _buildingService.SearchBuildingsAsync(BuildingVM);
            _navigationManager.NavigateTo("/Building/index/");
            StateHasChanged();
        }

        protected void PagerPageChanged(int page)
        {
            BuildingVM.PageNumber = page;
            _navigationManager.NavigateTo("/Building/index/" + page);

        }

        protected async override Task OnParametersSetAsync()
        {
            await GetBuildings();
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


