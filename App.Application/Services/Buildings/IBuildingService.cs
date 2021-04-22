using Application.App.Responses;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Services.Buildings
{
    public interface IBuildingService
    {
        Task<Guid> AddBuilding(BuildingDto building);

        Task<BaseResponse> DeleteBuildingAsync(Guid buildingId);
        Task<IReadOnlyList<Building>> BuildingListQuery();

        Task<BuildingDto> GetBuildingByIdAsync(Guid Id);
        Task<BuildingVM> SearchBuildingsAsync(BuildingVM buildingVM);
        Task UpdateBuilding(BuildingDto buildingDto);
    }
}
