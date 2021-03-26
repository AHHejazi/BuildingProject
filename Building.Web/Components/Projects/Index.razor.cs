using Application.App.Services.Projects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Building.Web.Components.Projects
{
    public partial class Index : ComponentBase
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        public IProjectService _projectService { get; set; }
        public ProjectVM ProjectVM=new ProjectVM();
      
        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        [Parameter]
        public string Page { get; set; } = "1";


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

        public async Task DeleteProject(Guid projectId)
        {
            await _projectService.DeleteProjectAsync(projectId);
            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }
    }
}
