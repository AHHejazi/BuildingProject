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
        Task<bool> IsBuildingNumberUnique(string Number);
        Task<BuildingVM> SearchAsync(BuildingVM buildingVM);

        Task<bool> CheckRelatedBuildingAsync(Guid projectId);
    }
}
