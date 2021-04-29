using Application.App.Services.Supplies;
using ComponentsLibrary.DeleteConfirmation;
using ComponentsLibrary.ErrorHandler;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Building.Web.Components.Supplies
{
    public partial class Index : PageBase
    {
        
        [Inject]
        public ISuppliesService _suppliesService { get; set; }
        public SuppliesVM suppliesVM = new SuppliesVM();

        [Parameter]
        public string Page { get; set; } = "1";

        protected DeleteDialog DeleteDialog { get; set; }

        private Guid SelectedSuppliId;

        [CascadingParameter(Name = "ErrorComponent")]
        protected IErrorComponent Error { get; set; }

        protected async Task SearchSupplies()
        {
            Page = "1";
            suppliesVM.PageNumber = 1;
            suppliesVM = await _suppliesService.SearchSupplyAsync(suppliesVM);
        }

        protected async Task GetSupplies()
        {
            suppliesVM = await _suppliesService.SearchSupplyAsync(suppliesVM);

        }
        protected async Task PagerPageChanged(int page)
        {

            suppliesVM.PageNumber = page;
            await GetSupplies();
            StateHasChanged(); 
        }

        protected async override Task OnInitializedAsync()
        {
            await GetSupplies();
        }


        protected void DeleteConfirmationSupply(Guid supplyId)
        {
            DeleteDialog.Show();
            SelectedSuppliId = supplyId;
            StateHasChanged();
        }

        public async Task DeleteDialog_OnDialogClose()
        {
            try
            {
                var deleteStatus = await _suppliesService.DeleteSupplyAsync(SelectedSuppliId);
                if (deleteStatus.Success)
                {
                    await GetSupplies();
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