using Application.App.Services.Supplies;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Supplies
{
    public partial class Details : ComponentBase
    {
        [Inject]
        public ISuppliesService _suppliesService { get; set; }
        public SuppliesDto supply;


        [Parameter]
        public Guid Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            supply = await _suppliesService.GetSupplyByIdAsync(Id);
        }
    }
}
