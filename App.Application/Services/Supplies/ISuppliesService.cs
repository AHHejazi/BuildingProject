using Application.App.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Services.Supplies
{
    public interface ISuppliesService
    {
        Task<Guid> AddSupply(SuppliesDto supply);
        Task<SuppliesDto> GetSuppliesByIdAsync(Guid Id);
        Task Updatesupply(SuppliesDto supplyDto);
        Task<SuppliesVM> SearchSuppliesAsync(SuppliesVM suppliesVM);
        Task DeleteSuppliesAsync(Guid supplyId);
    }
}
