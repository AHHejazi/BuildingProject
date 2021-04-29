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


        

        [Inject]
        public ISuppliesService _suppliesService { get; set; }

        public SuppliesDto supplyDto = new SuppliesDto();

        [Parameter]
        public Guid Id { get; set; }

        public EventCallback<SuppliesDto> OnValidSubmit { get; set; }

        protected async override Task OnInitializedAsync()
        {
            supplyDto = await _suppliesService.GetSupplyByIdAsync(Id);
        }

        private void SubmitSuppliesAsync()
        {
            _suppliesService.UpdateSupply(supplyDto);
                
        }
    }
}