using Application.App.Responses;
using System;
using System.Threading.Tasks;

namespace Application.App.Services.BuildingOuts
{
    public interface IBuildingOutService
    {
        Task<Guid> AddBuildingOutAsync(BuildingOutDto buildingOut);
        Task<BaseResponse> DeleteBuildingOutAsync(Guid buildingOutId);
        Task<BuildingOutDto> GetBuildingOutByIdAsync(int Id);
        //Task<BuildingOutVM> SearchBuildingOutAsync(BuildingOutVM buildingOutVM);
        Task UpdateBuildingOutAsync(BuildingOutDto buildingOutDto);
    }
}