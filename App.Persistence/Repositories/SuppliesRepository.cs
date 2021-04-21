using App.Application.Contracts.Persistence;
using Application.App.Services.Supplies;
using Domain.App.Entities.Lookup;
using Framework.Core.ListManagment;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class SuppliesRepository : BaseRepository<Supplement>, ISuppliesRepository
    {
        public SuppliesRepository(BuildingDbContext dbContext) : base(dbContext)
        {
           
        }
        public async Task<SuppliesVM> SearchAsync(SuppliesVM suppliesVM)
        {

            var filters = new Filters<Supplement>();

            filters.Add(!string.IsNullOrEmpty(suppliesVM.NameAr), u => u.NameAr.Contains(suppliesVM.NameAr));
            filters.Add(!string.IsNullOrEmpty(suppliesVM.NameEn), u => u.NameEn.Contains(suppliesVM.NameEn));

            var result = await _dbContext.Suppliess.AsNoTracking().Paginate(suppliesVM.PageNumber, suppliesVM.PageSize, filters);

            suppliesVM.SuppliesList =
               new StaticPagedList<Supplement>(
                   result.Results,
                   result.CurrentPage,
                   result.PageSize,
                   result.RecordCount);

            return suppliesVM;
        }

        public async Task<bool> IsSupplyNameUnique(string nameAr, string nameEn)
        {
            return await _dbContext.Suppliess.AnyAsync(x => x.NameAr == nameAr || x.NameEn == nameEn);
        }
    }
}
