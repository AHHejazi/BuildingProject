using Application.App.Responses;
using System;
using System.Threading.Tasks;

namespace Application.App.Services.Supplies
{
    public interface ISuppliesService
    {
        Task<Guid> AddSupply(SuppliesDto supply);
        Task<BaseResponse> DeleteSuppliesAsync(Guid supplyId);
        Task<string> GenerateSuppliesNumber();
        Task<SuppliesDto> GetSuppliesByIdAsync(Guid Id);
        Task<SuppliesVM> SearchSuppliesAsync(SuppliesVM suppliesVM);
        Task UpdateSupply(SuppliesDto supplyDto);
    }
}