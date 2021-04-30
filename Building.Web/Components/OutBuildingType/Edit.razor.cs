using Application.App.Services.Outbuildings;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.OutBuildingType
{
    public partial class Edit : PageBase
    {
        [Inject]
        public IOutbuildingTypeService _outbuildingService { get; set; }

        public OutbuildingTypeDto outbuilding;

        [Parameter]
        public int Id { get; set; }


        protected async override Task OnInitializedAsync()
        {
            outbuilding = await _outbuildingService.GetOutbuildingTypeByIdAsync(Id);
        }

        public void SubmitoutbuildingAsync()
        {
            _outbuildingService.UpdateOutbuildingTypeAsync(outbuilding);
        }
    }
}
