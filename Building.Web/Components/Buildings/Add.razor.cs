using Application.App.Services.Buildings;
using Application.App.Services.Lookups;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
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
        private ILookupServices _lookupServices { get; set; }
      

        [Parameter]
        public Guid Id { get; set; }

    


        private void SubmitBuildingAsync()
        {
            Console.WriteLine("Form Submitted Successfully!");
        }
    }
}
