using Application.App.Responses;
using System;
using System.Threading.Tasks;

namespace Application.App.Services.Outbuildings
{
    public interface IOutbuildingTypeService
    {
        Task<Guid> AddOutbuildingTypeAsync(OutbuildingTypeDto outbuilding);
        Task<BaseResponse> DeleteOutbuildingTypeAsync(Guid outbuildingTypeId);
        Task<OutbuildingTypeDto> GetOutbuildingTypeByIdAsync(int Id);
        Task<OutbuildingTypeVM> SearchOutbuildingTypeAsync(OutbuildingTypeVM outbuildingVM);
        Task UpdateOutbuildingTypeAsync(OutbuildingTypeDto outbuildingDto);
    }
}