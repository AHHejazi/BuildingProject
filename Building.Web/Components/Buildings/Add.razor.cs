using Application.App.Services.Buildings;
using Application.App.Services.Lookups;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Buildings
{
    public partial class Add : PageBase
    {
        public BuildingDto Model = new BuildingDto();
        

        [Inject]
        private NavigationManager _navigationManager { get; set; }
       
        [Inject]
        private IBuildingService _buildingService { get; set; }

        [Inject]
        private ILookupServices _lookupServices { get; set; }
        private EditContext editContext;

        [Parameter]
        public Guid Id { get; set; }
        public EventCallback<BuildingDto> OnValidSubmit { get; set; }

        protected async override Task OnInitializedAsync()
        {
            editContext = new EditContext(Model);
        }
        private async Task SubmitBuildingAsync()
        {
            var isValid = editContext.Validate();

            if (isValid)
            {

                var retObjid = await _buildingService.AddBuilding(Model);
                StatusClass = "alert alert-success";
                Message = "New Building added successfully.";
            }
            else
            {
                StatusClass = "alert alert-danger";
                Message = "Something went wrong adding the new Building. Please try again.";
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
