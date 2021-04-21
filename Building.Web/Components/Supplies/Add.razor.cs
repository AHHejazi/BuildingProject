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
    public partial class Add : PageBase
    {
        [Inject]
        private ISuppliesService _suppliesService { get; set; }
        public SuppliesDto Model = new SuppliesDto();
        private EditContext editContext;

        protected async override Task OnInitializedAsync()
        {
            editContext = new EditContext(Model);
        }
        private async Task SubmitSuppliesAsync()
        {
            var isValid = editContext.Validate();

            if (isValid)
            {
                
                await _suppliesService.AddSupply(Model);
                StatusClass = "alert alert-success";
                Message = "New Supply added successfully.";
            }
            else
            {
                StatusClass = "alert alert-danger";
                Message = "Something went wrong adding the new Supply. Please try again.";
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
