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
        
       Task DeleteBuildingAsync(Guid buildingId);

        Task<IReadOnlyList<Building>> BuildingListQuery();


        Task<BuildingDto> GetBuildingByIdAsync(Guid Id);
        //Task<BuildingVM> SearchBuildingAsync(BuildingVM buildingVM);
        Task UpdateBuilding(BuildingDto buildingDto);
        Task<BuildingVM> SearchBuildingAsync(BuildingVM buildingVM);
    }
}
