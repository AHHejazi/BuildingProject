using Application.App.Contracts.Persistence;
using Application.App.Services.Buildings;
using Domain.App.Entities;
using Framework.Core.ListManagment;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(IDbContextFactory<BuildingDbContext> dbContext) : base(dbContext)
        {

        }

        public async Task<bool> CheckRelatedBuildingAsync(Guid projectId)
        {
            var isRelated = await _dbContext.Buildings.AnyAsync(x => x.ProjectId == projectId);

            return isRelated;
        }

        public async Task<bool> IsBuildingNumberUnique(string number)
        {
          return await _dbContext.Buildings.AnyAsync(x => x.Number == number);
        }


        public async Task<BuildingVM> SearchAsync(BuildingVM buildingVM)
        {

            var filters = new Filters<Building>();

            filters.Add(buildingVM.ProjectId.HasValue, u => u.ProjectId == buildingVM.ProjectId);
            filters.Add(buildingVM.EstimatedCost.HasValue, u => u.EstimatedCost == buildingVM.EstimatedCost);
            filters.Add(buildingVM.NumberOfFloor.HasValue, u => u.NumberOfFloor == buildingVM.NumberOfFloor); ;
            var result = await _dbContext.Buildings.AsNoTracking().Paginate(buildingVM.PageNumber, buildingVM.PageSize, filters);

            buildingVM.BuildingList =
               new StaticPagedList<Building>(
                   result.Results,
                   result.CurrentPage,
                   result.PageSize,
                   result.RecordCount);

            return buildingVM;
        }


    }
}


