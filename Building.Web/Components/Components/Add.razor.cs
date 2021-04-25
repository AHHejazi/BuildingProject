using Application.App.Services.Components;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace Building.Web.Components.Components
{
    public partial class Add : PageBase
    {
        [Inject]
        private IComponentService _componentService { get; set; }
        public ComponentDto Model { get; set; } = new();
        private EditContext editContext;

        protected async override Task OnInitializedAsync()
        {
            editContext = new EditContext(Model);
        }
        private async Task SubmitComponentAsync()
        {
            var isValid = editContext.Validate();

            if (isValid)
            {

                await _componentService.AddComponent(Model);
                StatusClass = "alert alert-success";
                Message = "New Component added successfully.";
            }
            else
            {
                StatusClass = "alert alert-danger";
                Message = "Something went wrong adding the new Component. Please try again.";
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
