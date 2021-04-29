using Application.App.Contracts.Persistence;
using Application.App.Services.Outbuildings;
using Domain.App.Entities;
using Framework.Core.Globalization;
using Framework.Core.ListManagment;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class OutbuildingRepository : BaseRepository<Outbuilding>, IOutbuildingRepository
    {
        public OutbuildingRepository(BuildingDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> IsOutbuildingNameUnique(string nameAr, string nameEn)
        {
            return await _dbContext.Outbuildings.AnyAsync(x => x.NameAr == nameAr || x.NameEn == nameEn);
        }

        public Task UpdateAsync(OutbuildingDto Outbuilding)
        {
            throw new NotImplementedException();
        }

        public async Task<OutbuildingVM> SearchAsync(OutbuildingVM outbuildingVM)
        {

            var filters = new Filters<Outbuilding>();

            filters.Add(!string.IsNullOrEmpty(outbuildingVM.NameAr), u => u.NameAr.Contains(outbuildingVM.NameAr));
            filters.Add(!string.IsNullOrEmpty(outbuildingVM.NameEn), u => u.NameEn.Contains(outbuildingVM.NameEn));

            var result = await _dbContext.Outbuildings.AsNoTracking().Paginate(outbuildingVM.PageNumber, outbuildingVM.PageSize, filters);

            outbuildingVM.OutbuildingsList =
            new StaticPagedList<Outbuilding>(
                result.Results,
                result.CurrentPage,
                result.PageSize,
                result.RecordCount);

            return outbuildingVM;
        }

        public async Task<IEnumerable<SelectListItem>> OutbuildingListByCurrentUserAsync(string userName)
        {
            //TODO you have to remove userName when u can get the userName correctly
            return await _dbContext.Outbuildings.Where(c => c.CreatedBy == userName || string.IsNullOrEmpty(userName))
            .Select(s =>
                 new SelectListItem(
                    CultureHelper.IsArabic ? s.NameAr : s.NameEn, s.Id.ToString())).ToListAsync();
        }
    }
}
