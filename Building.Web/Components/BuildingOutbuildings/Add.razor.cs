using Application.App.Services.Components;
using Application.App.Services.Outbuildings;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.BuildingOutbuildings
{
    public partial class Add : PageBase
    {
        [Inject]
        public IComponentService _componentService { get; set; }
        [Inject]
        public IOutbuildingService _outbuildingService { get; set; }

        private IEnumerable<SelectListItem> ComponentList;
        private IEnumerable<SelectListItem> OutbuildingList;
        public ComponentDto Model { get; set; } = new();







        private async Task SubmitBuildingOutbuildingsAsync()
        {
            try
            {
                await _componentService.AddBuildingOutbuildings(Model);
                StatusClass = "alert alert-success";
                Message = "New Building Outbuilding added successfully.";
            }
            catch (Exception)
            {

                StatusClass = "alert alert-danger";
                Message = "Something went wrong adding the new Building Outbuilding. Please try again.";

            }

        }
    }
}