using Application.App.Services.Buildings;
using Application.App.Services.Projects;
using ComponentsLibrary.DeleteConfirmation;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComponentsLibrary.ErrorHandler;

namespace Building.Web.Components.Buildings
{
    public partial class Index : PageBase
    {
        private IEnumerable<SelectListItem> ProjectList;
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        public IProjectService _projectService { get; set; }
        [Inject]
        public IBuildingService _buildingService { get; set; }
        public BuildingVM BuildingVM = new BuildingVM();



        [Parameter]
        public string Page { get; set; } = "1";
        protected DeleteDialog DeleteDialog { get; set; }

        private Guid SelectedBuildingId;

        [CascadingParameter(Name = "ErrorComponent")]
        protected IErrorComponent Error { get; set; }


        //protected override async Task OnInitializedAsync()
        //{
        //    ProjectList = await _projectService.ProjectListByCurrentUserAsync();
        //}
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
        protected void DeleteConfirmationBuilding(Guid buildingId)
        {
            DeleteDialog.Show();
            SelectedBuildingId = buildingId;
            StateHasChanged();
        }

        public async Task DeleteDialog_OnDialogClose()
        {
            try
            {
                var deleteStatus = await _buildingService.DeleteBuildingAsync(SelectedBuildingId);

                if (deleteStatus.Success)
                {
                    await GetBuildings();
                }
                else
                {
                    StatusClass = "alert alert-danger";
                    Message = deleteStatus.Message;
                }

                StateHasChanged();
            }
            catch (Exception e)
            {
                Error.SetError(e.Message, e.StackTrace);
                Error.ProcessError(e);
            }
        }


    }
}


