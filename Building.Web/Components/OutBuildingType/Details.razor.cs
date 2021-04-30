using Application.App.Services.Outbuildings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.OutBuildingType
{
    public partial class Details : ComponentBase
    {
        [Inject]
        public IOutbuildingTypeService _outbuildingService { get; set; }
        public OutbuildingTypeDto outbuilding;


        [Parameter]
        public int Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            outbuilding = await _outbuildingService.GetOutbuildingTypeByIdAsync(Id);
        }
    }
}
