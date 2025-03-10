﻿using Application.App.Services.Projects;
using ComponentsLibrary.DeleteConfirmation;
using ComponentsLibrary.ErrorHandler;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Building.Web.Components.Projects
{
    public partial class Index : PageBase
    {

        [Inject]
        public IProjectService _projectService { get; set; }

        public ProjectVM ProjectVM = new ProjectVM();

        [Parameter]
        public string Page { get; set; } = "1";

        private Guid SelectedPrjectId;
        
        [CascadingParameter(Name = "ErrorComponent")]
        protected IErrorComponent Error { get; set; }
        protected DeleteDialog DeleteDialog { get; set; }
        protected async Task SearchProjects()
        {
            Page = "1";
            ProjectVM.PageNumber = 1;
            ProjectVM = await _projectService.SearchProjectsAsync(ProjectVM);
        }


        protected async Task GetProjects()
        {
            ProjectVM = await _projectService.SearchProjectsAsync(ProjectVM);

        }

        protected async Task PagerPageChanged(int page)
        {
            ProjectVM.PageNumber = page;
            await GetProjects();
            StateHasChanged();
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

        public async Task DeleteDialog_OnDialogClose()
        {
            try
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
            catch (Exception e)
            {
                Error.SetError(e.Message, e.StackTrace);
                Error.ProcessError(e);
            }

        }
    }
}
