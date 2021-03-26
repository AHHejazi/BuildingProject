using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.App.Contracts.Persistence
{
   public interface ILookupRepository
    {
        public Task<IEnumerable<SelectListItem>> GetProjectTypeList(CancellationToken cancellationToken = default);

        public Task<IEnumerable<SelectListItem>> GetOutbuildingsTypes();
        public Task<IEnumerable<SelectListItem>> GetBuildingTypeList(CancellationToken cancellationToken = default);
    }
}
