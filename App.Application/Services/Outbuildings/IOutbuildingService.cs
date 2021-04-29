using Application.App.Responses;
using System;
using System.Threading.Tasks;

namespace Application.App.Services.Outbuildings
{
    public interface IOutbuildingService
    {
        Task<Guid> AddOutbuilding(OutbuildingDto outbuilding);
        Task<BaseResponse> DeleteOutbuildingAsync(Guid outbuildingId);
        Task<string> GenerateOutbuildingNumber();
        Task<OutbuildingDto> GetOutbuildingByIdAsync(Guid Id);
        Task<OutbuildingVM> SearchOutbuildingAsync(OutbuildingVM outbuildingVM);
        Task UpdateOutbuilding(OutbuildingDto outbuildingDto);
    }
}