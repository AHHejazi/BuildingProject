using Application.App.Responses;
using System;
using System.Threading.Tasks;

namespace Application.App.Services.Supplies
{
    public interface ISuppliesService
    {
        Task<Guid> AddSupply(SuppliesDto supply);
        Task<BaseResponse> DeleteSupplyAsync(Guid supplyId);
        Task<string> GenerateSupplyNumber();
        Task<SuppliesDto> GetSupplyByIdAsync(Guid Id);
        Task<SuppliesVM> SearchSupplyAsync(SuppliesVM suppliesVM);
        Task UpdateSupply(SuppliesDto supplyDto);
    }
}