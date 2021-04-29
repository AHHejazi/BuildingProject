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

        [Inject]
        public IComponentService _componentService { get; set; }

        public ComponentDto componentDto = new ComponentDto();
        public EventCallback<ComponentDto> OnValidSubmit { get; set; }

        [Parameter]
        public Guid Id { get; set; }


        protected async override Task OnInitializedAsync()
        {

            componentDto = await _componentService.GetComponentByIdAsync(Id);
        }

        private void SubmitComponentAsync()
        {
            _componentService.UpdateComponent(componentDto);
        }
    }
}