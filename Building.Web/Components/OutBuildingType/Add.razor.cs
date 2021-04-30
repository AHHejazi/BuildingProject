using Application.App.Services.Outbuildings;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.OutBuildingType
{
    public partial class Add : PageBase
    {
        [Inject]
        private IOutbuildingTypeService _outbuildingService { get; set; }
        public OutbuildingTypeDto Model { get; set; } = new();
        private EditContext editContext;

        protected async override Task OnInitializedAsync()
        {
            editContext = new EditContext(Model);
        }
        private async Task SubmitOutbuildingAsync()
        {
            var isValid = editContext.Validate();

            if (isValid)
            {

                await _outbuildingService.AddOutbuildingTypeAsync(Model);
                StatusClass = "alert alert-success";
                Message = "New Outbuilding added successfully.";
            }
            else
            {
                StatusClass = "alert alert-danger";
                Message = "Something went wrong adding the new Outbuilding. Please try again.";
            }
        }

        public async Task ValidateForm(EditContext editContext)
        {

            var isValid = editContext.Validate();

            if (!isValid)
                return;

        }
    }
}
