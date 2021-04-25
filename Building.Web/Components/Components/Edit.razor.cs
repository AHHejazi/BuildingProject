using Application.App.Services.Components;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Threading.Tasks;

namespace Building.Web.Components.Components
{
    public partial class Edit : PageBase
    {

        public ComponentDto componentDto = new ComponentDto();

        private EditContext editContext;

        [Inject]
        public IComponentService _componentService { get; set; }

        [Parameter]
        public EventCallback<ComponentDto> OnValidSubmit { get; set; }

        [Parameter]
        public Guid Id { get; set; }
        protected async override Task OnParametersSetAsync()
        {

            componentDto = await _componentService.GetComponentByIdAsync(Id);
            editContext = new EditContext(componentDto);
        }

        private async Task SubmitComponentAsync()
        {

            var isValid = editContext.Validate();

            if (isValid)
            {
                await _componentService.UpdateComponent(componentDto);
                StatusClass = "alert alert-success";
                Message = "Building updated successfully.";
            }
            else
            {
                StatusClass = "alert alert-danger";
                Message = "Something went wrong while updating Component . Please try again.";
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