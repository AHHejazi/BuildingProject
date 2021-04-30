using Application.App.Services.Outbuildings;
using ComponentsLibrary.DeleteConfirmation;
using ComponentsLibrary.ErrorHandler;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Building.Web.Components.OutBuildingType
{
    public partial class Index : PageBase
    {
        [Inject]
        public IOutbuildingTypeService _outbuildingService { get; set; }

        public OutbuildingTypeVM OutbuildingVM = new OutbuildingTypeVM();

        [Parameter]
        public string Page { get; set; } = "1";

        private Guid SelectedOutbuildingId;
        protected DeleteDialog DeleteDialog { get; set; }

       [CascadingParameter(Name = "ErrorComponent")]
        protected IErrorComponent Error { get; set; }

        protected async Task SearchOutbuildings()
        {
            Page = "1";
            OutbuildingVM.PageNumber = 1;
            OutbuildingVM = await _outbuildingService.SearchOutbuildingTypeAsync(OutbuildingVM);
        }


        protected async Task GetOutbuildings()
        {
            OutbuildingVM = await _outbuildingService.SearchOutbuildingTypeAsync(OutbuildingVM);

        }

        protected async Task PagerPageChanged(int page)
        {
            OutbuildingVM.PageNumber = page;
            await GetOutbuildings();
            StateHasChanged();
        }

        protected async override Task OnParametersSetAsync()
        {
            await GetOutbuildings();
        }


        protected void DeleteConfirmationOutbuilding(Guid outbuildingId)
        {
            DeleteDialog.Show();
            SelectedOutbuildingId = outbuildingId;
            StateHasChanged();
        }

        public async Task DeleteDialog_OnDialogClose()
        {
            try
            {
                var deleteStatus = await _outbuildingService.DeleteOutbuildingTypeAsync(SelectedOutbuildingId);
                if (deleteStatus.Success)
                {
                    await GetOutbuildings();
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
