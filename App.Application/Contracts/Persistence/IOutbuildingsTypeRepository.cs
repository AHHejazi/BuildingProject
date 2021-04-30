using Application.App.Services.Outbuildings;
using Domain.App.Entities.Lookup;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.App.Contracts.Persistence
{
    public interface IOutbuildingsTypeRepository : IAsyncRepository<OutbuildingsType>
    {
        Task<bool> IsOutbuildingNameUnique(string nameAr, string nameEn);
        Task UpdateAsync(OutbuildingTypeDto outbuilding);
        Task<OutbuildingTypeVM> SearchAsync(OutbuildingTypeVM outbuildingVM);
        Task<IEnumerable<SelectListItem>> OutbuildingListByCurrentUserAsync(string userName);
    }
}
