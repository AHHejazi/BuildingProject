using Application.App.Services.Buildings;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Contracts.Persistence
{
    public interface IBuildingRepository : IAsyncRepository<Building>
    {
        Task<bool> IsBuildingNameUnique(string Number);
        //Task<BuildingVM> SearchAsync(BuildingVM projectVM);
        // Task UpdateAsync(BuildingDto building);
        // Task<BuildingVM> SearchAsync(BuildingVM buildingVM);

    }
}
