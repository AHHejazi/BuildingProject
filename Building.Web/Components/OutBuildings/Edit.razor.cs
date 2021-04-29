using Application.App.Services.Outbuildings;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.OutBuildings
{
    public partial class Edit : PageBase
    {
        [Inject]
        public IOutbuildingService _outbuildingService { get; set; }

        public OutbuildingDto outbuilding;

        [Parameter]
        public Guid Id { get; set; }


        protected async override Task OnInitializedAsync()
        {
            outbuilding = await _outbuildingService.GetOutbuildingByIdAsync(Id);
        }

        public void SubmitoutbuildingAsync()
        {
            _outbuildingService.UpdateOutbuilding(outbuilding);
        }
    }
}
