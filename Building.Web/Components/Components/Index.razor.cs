using Application.App.Services.Components;
using ComponentsLibrary.DeleteConfirmation;
using ComponentsLibrary.ErrorHandler;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Building.Web.Components.Components
{
    public partial class Index : PageBase
    {
        [Inject]
        public IComponentService _componentService { get; set; }

        public ComponentVM componentVM = new ComponentVM();

        [Parameter]
        public string Page { get; set; } = "1";

        private Guid SelectedComponentId;
        protected DeleteDialog DeleteDialog { get; set; }
        
        [CascadingParameter(Name = "ErrorComponent")]
        protected IErrorComponent Error { get; set; }

        protected async Task SearchComponent()
        {
            Page = "1";
            componentVM.PageNumber = 1;
            componentVM = await _componentService.SearchComponentAsync(componentVM);
            
        }

        protected async Task GetComponents()
        {
            componentVM = await _componentService.SearchComponentAsync(componentVM);

        }
        protected async Task PagerPageChanged(int page)
        {
            componentVM.PageNumber = page;
            await GetComponents();
            StateHasChanged();
        }

        protected async override Task OnInitializedAsync()
        {
            await GetComponents();
        }


        protected void DeleteConfirmationComponent(Guid componentId)
        {
            DeleteDialog.Show();
            SelectedComponentId = componentId;
            StateHasChanged();
        }

        public async Task DeleteDialog_OnDialogClose()
        {
            try
            {
                var deleteStatus = await _componentService.DeleteComponentAsync(SelectedComponentId);
                if (deleteStatus.Success)
                {
                    await GetComponents();
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