using Application.App.Contracts.Persistence;
using Application.App.Services.Buildings;
using Domain.App.Entities;
using Framework.Core.ListManagment;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
   public class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        private readonly BuildingDbContext _dbContext;
        public BuildingRepository(BuildingDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;

        }

        public async Task<bool> IsBuildingNumberUnique(string number)
        {
          return await _dbContext.Buildings.AnyAsync(x => x.Number == number);
        }


        public async Task<BuildingVM> SearchAsync(BuildingVM buildingVM)
        {

            var filters = new Filters<Building>();

            filters.Add(!string.IsNullOrEmpty(buildingVM.Number), u => u.Number.Contains(buildingVM.Number));

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


