using Application.App.Services.Components;
using Application.App.Services.Supplies;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Components
{
    public partial class Details : ComponentBase
    {
        [Inject]
        public IComponentService _componentService { get; set; }
        public ComponentDto component;


        [Parameter]
        public Guid Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            component = await _componentService.GetComponentByIdAsync(Id);
        }
    }
}
