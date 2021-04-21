using Application.App.Contracts.Persistence;
using Application.App.Services.Supplies;
using Domain.App.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Contracts.Persistence
{
    public interface ISuppliesRepository: IAsyncRepository<Supplement>
    {
        Task<SuppliesVM> SearchAsync(SuppliesVM suppliesVM);
        Task<bool> IsSupplyNameUnique(string nameAr, string nameEn);

    }
}
