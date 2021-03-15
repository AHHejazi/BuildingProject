using Application.App.Contracts.Persistence;
using AutoMapper;
using Domain.App.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Services.Buildings
{
    public class BuildingService : IBuildingService
    {
        
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BuildingDto> _logger;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        public BuildingService(IMapper mapper, IBuildingRepository buildingRepository, ILogger<BuildingDto> logger)
        {
            _mapper = mapper;
            _buildingRepository = buildingRepository;
            _logger = logger;
        }

        public async Task<Guid> AddBuilding(BuildingDto building)
        {
            var validator = new BuildingValidator(_buildingRepository);
            var validationResult = await validator.ValidateAsync(building);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            var build = _mapper.Map<Building>(building);
            build = await _buildingRepository.AddAsync(build);
            return build.Id;
        }



        public Task DeleteBuildingAsync(Guid buildingId)
        {
            throw new NotImplementedException();
        }

        //public Task<Building> GetBuildingByIdAsync(Guid Id)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<BuildingVM> SearchBuildingAsync(BuildingVM buildingVM)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBuilding(BuildingDto buildingDto)
        {
            throw new NotImplementedException();
        }



        public async Task<Building> GetBuildingByIdAsync(Guid Id)
        {
            var obj = await _buildingRepository.GetByIdAsync(Id);
            return obj;

        }

        //public async Task UpdateBuilding(BuildingDto building)
        //{
        //    await _buildingRepository.UpdateAsync(building);
        //    StatusClass = "alert-success";
        //    Message = "Building updated successfully.";
        //    Saved = true;
        //}

        //public async Task DeleteBuildingAsync(Guid buildingId)
        //{
        //    await _buildingRepository.DeleteAsync(buildingId);
        //}



        public async Task<IReadOnlyList<Building>> BuildingListQuery()
        {
            var result = await _buildingRepository.ListAllAsync();
            return result;
        }

        //public async Task<BuildingVM> SearchBuildingAsync(BuildingVM projectVM)
        //{
        //    return await _buildingRepository.SearchAsync(projectVM);
        //}





    }

}
