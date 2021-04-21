using Application.App.Services.Supplies;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Supplies
{
    public partial class Edit : PageBase
    {

        public SuppliesDto supplyDto = new SuppliesDto();

        private EditContext editContext;

        [Inject]
        public ISuppliesService _suppliesService { get; set; }

        [Parameter]
        public EventCallback<SuppliesDto> OnValidSubmit { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        protected async override Task OnParametersSetAsync()
        {

            supplyDto = await _suppliesService.GetSuppliesByIdAsync(Id);
            editContext = new EditContext(supplyDto);
        }

        private async Task SubmitSuppliesAsync()
        {

            var isValid = editContext.Validate();

            if (isValid)
            {
                await _suppliesService.Updatesupply(supplyDto);
                StatusClass = "alert alert-success";
                Message = "Building updated successfully.";
            }
            else
            {
                StatusClass = "alert alert-danger";
                Message = "Something went wrong while updating Supply . Please try again.";
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