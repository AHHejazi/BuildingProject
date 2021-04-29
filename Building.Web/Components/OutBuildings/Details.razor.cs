using Application.App.Services.Outbuildings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.OutBuildings
{
    public partial class Details : ComponentBase
    {
        [Inject]
        public IOutbuildingService _outbuildingService { get; set; }
        public OutbuildingDto outbuilding;


        [Parameter]
        public Guid Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            outbuilding = await _outbuildingService.GetOutbuildingByIdAsync(Id);
        }
    }
}
