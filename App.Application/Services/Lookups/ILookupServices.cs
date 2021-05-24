using Application.App.Services.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.App.Services.Lookups
{
    public interface ILookupServices
    {
       public Task<IEnumerable<SelectListItem>> GetProjectTypeList();

        public Task<IEnumerable<SelectListItem>> GetBuildingList();
        public Task<IEnumerable<SelectListItem>> GetComponentList();
        public Task<IEnumerable<SelectListItem>> GetOutbuildingTypeList();
        public Task<ComponentDto> GetComponentByIdAsync(Guid Id);
    }
}
