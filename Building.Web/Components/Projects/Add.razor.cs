using Application.App.Services.Lookups;
using Domain.App.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Projects
{
    public partial class Add : ComponentBase
    {
        public Project Model = new Project();

        [Inject]
        private NavigationManager _navigationManager { get; set; }


        [Inject]
        private ILookupServices _lookupServices { get; set; }

        

        private void SubmitProject()
        {
            _navigationManager.NavigateTo("/Back");
        }
    }
}
