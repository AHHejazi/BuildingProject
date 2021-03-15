using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.App.Services.Lookups
{
    public interface ILookupServices
    {
       public Task<IEnumerable<SelectListItem>> GetProjectTypeList();
        public Task<IEnumerable<SelectListItem>> GetBuildingTypeList();
    }
}
