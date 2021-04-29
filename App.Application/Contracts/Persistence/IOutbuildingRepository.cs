using Application.App.Services.Outbuildings;
using Domain.App.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Contracts.Persistence
{
    public interface IOutbuildingRepository : IAsyncRepository<Outbuilding>
    {
        Task<bool> IsOutbuildingNameUnique(string nameAr, string nameEn);
        Task UpdateAsync(OutbuildingDto outbuilding);
        Task<OutbuildingVM> SearchAsync(OutbuildingVM outbuildingVM);
        Task<IEnumerable<SelectListItem>> OutbuildingListByCurrentUserAsync(string userName);
    }
}
