using Application.App.Services.Components;
using Application.App.Services.Supplies;
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
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        public IComponentService _componentService { get; set; }
        public ComponentVM componentVM = new ComponentVM();

        [Parameter]
        public string Page { get; set; } = "1";

        protected DeleteDialog DeleteDialog { get; set; }

        private Guid SelectedComponentId;

        [CascadingParameter(Name = "ErrorComponent")]
        protected IErrorComponent Error { get; set; }

        protected async Task SearchComponent()
        {
            Page = "1";
            componentVM.PageNumber = 1;
            componentVM = await _componentService.SearchComponentAsync(componentVM);
            _navigationManager.NavigateTo("/Component/index/" + Page);
            StateHasChanged();
        }

        protected async Task GetComponent()
        {
            componentVM = await _componentService.SearchComponentAsync(componentVM);

        }
        protected void PagerPageChanged(int page)
        {
            componentVM.PageNumber = page;
            _navigationManager.NavigateTo("/Component/index/" + page);

        }

        protected async override Task OnInitializedAsync()
        {
            await GetComponent();
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
                    await GetComponent();
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