using App.Application.Contracts.Persistence;
using Application.App.Services.Components;
using Domain.App.Entities.Lookup;
using Framework.Core.ListManagment;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class ComponentRepository : BaseRepository<Component>, IComponentRepository
    {
        public ComponentRepository(BuildingDbContext dbContext) : base(dbContext)
        {
           
        }
        public async Task<ComponentVM> SearchAsync(ComponentVM componentVM)
        {

            var filters = new Filters<Component>();

            filters.Add(!string.IsNullOrEmpty(componentVM.NameAr), u => u.NameAr.Contains(componentVM.NameAr));
            filters.Add(!string.IsNullOrEmpty(componentVM.NameEn), u => u.NameEn.Contains(componentVM.NameEn));

            var result = await _dbContext.Components.AsNoTracking().Paginate(componentVM.PageNumber, componentVM.PageSize, filters);

            componentVM.ComponentsList =
               new StaticPagedList<Component>(
                   result.Results,
                   result.CurrentPage,
                   result.PageSize,
                   result.RecordCount);

            return componentVM;
        }

        public async Task<bool> IsComponentNameUnique(string nameAr, string nameEn)
        {
            return //Task.FromResult(true);
                await _dbContext.Components.AnyAsync(x => x.NameAr == nameAr || x.NameEn == nameEn);
        }

        
    }
}
