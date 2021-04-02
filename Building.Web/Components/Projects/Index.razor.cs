using Application.App.Services.Projects;
using ComponentsLibrary.DeleteConfirmation;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Building.Web.Components.Projects
{
    public partial class Index : PageBase
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        public IProjectService _projectService { get; set; }
        public ProjectVM ProjectVM=new ProjectVM();
      
        [Parameter]
        public string Page { get; set; } = "1";

        protected DeleteDialog DeleteDialog { get; set; }

        private Guid SelectedPrjectId;

        protected override async Task OnInitializedAsync()
        {
            await GetProjects();
        }

        protected async  Task SearchProjects()
        {
            Page = "1";
            ProjectVM.PageNumber = 1;
            ProjectVM = await _projectService.SearchProjectsAsync(ProjectVM);
            _navigationManager.NavigateTo("/Project/index/" + Page);
            StateHasChanged();
        }


        protected async Task GetProjects()
        {
            ProjectVM = await _projectService.SearchProjectsAsync(ProjectVM);
            _navigationManager.NavigateTo("/Project/index/");
            StateHasChanged();
        }

        protected void PagerPageChanged(int page)
        {
            ProjectVM.PageNumber = page;
           _navigationManager.NavigateTo("/Project/index/" + page);
            
        }

        protected async override Task OnParametersSetAsync()
        {
            await GetProjects();
        }

        protected void DeleteConfirmationProject(Guid projectId)
        {
            DeleteDialog.Show();
            SelectedPrjectId = projectId;
            StateHasChanged();
        }

        public async void DeleteDialog_OnDialogClose()
        {
           var deleteStatus = await _projectService.DeleteProjectAsync(SelectedPrjectId);

            if (deleteStatus.Success)
            {
                await GetProjects();
            }
            else
            {
                StatusClass = "alert alert-danger";
                Message = deleteStatus.Message;
            }

            StateHasChanged();
        }
    }
}
