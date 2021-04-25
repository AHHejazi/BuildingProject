using Application.App.Contracts.Persistence;
using Application.App.Contracts.UOW;
using Application.App.Responses;
using AutoMapper;
using Domain.App.Entities;
using Framework.Core.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.App.Services.Buildings
{
    public class BuildingService : IBuildingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        public BuildingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddBuilding(BuildingDto building)
        {
            try
            {
                var validator = new BuildingValidator(_unitOfWork.Buildings);
                var validationResult = await validator.ValidateAsync(building);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);
                var build = _mapper.Map<Building>(building);
                build.Number = GenerateBuildingNumber();

                build = await _unitOfWork.Buildings.AddAsync(build);
                await _unitOfWork.SaveChangesAsync();
                return build.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateBuildingNumber()
        {
            var currentYear = DateTime.Now.Year.ToString().Substring(2, 2);
            var currentMonth = DateTime.Now.Month.ToString("d2");

            Expression<Func<Building, bool>> condtion = r => r.Number.StartsWith($"{currentYear}-{currentMonth}");
            Expression<Func<Building, string>> orderBy = r => r.Number;


            var lastInsertedBuilding = _unitOfWork.Buildings.GenerateModelNumber(condtion, orderBy);

            if (lastInsertedBuilding == null)
            {
                return $"{currentYear}-{currentMonth}-0001";
            }

            var currentNo = int.Parse(lastInsertedBuilding.Number.Substring(6, 4));
            return $"{currentYear}-{currentMonth}-{(currentNo + 1):d4}";
        }





        public async Task UpdateBuilding(BuildingDto buildingDto)
        {
            var building = _mapper.Map<Building>(buildingDto);
            await _unitOfWork.Buildings.UpdateAsync(building);
        }



        public async Task<BuildingDto> GetBuildingByIdAsync(Guid Id)
        {
            Expression<Func<Building, bool>> condtion = r => r.Id == Id;

            var obj = await _unitOfWork.Buildings.GetByIdAsync(condtion);
            var retObj = _mapper.Map<BuildingDto>(obj);
            return retObj;

        }



        public async Task<IReadOnlyList<Building>> BuildingListQuery()
        {
            var result = await _unitOfWork.Buildings.ListAllAsync();
            return result;
        }

        public async Task<BuildingVM> SearchBuildingsAsync(BuildingVM buildingVM)
        {
            return await _unitOfWork.Buildings.SearchAsync(buildingVM);
        }

        public async Task<BaseResponse> DeleteBuildingAsync(Guid buildingId)
        {

            var baseResponse = new BaseResponse();
            try
            {

                var building = _unitOfWork.Buildings.GetByIdAsync(buildingId);

                if (building == null)
                {
                    throw new NotFoundException(nameof(building), buildingId);
                }

                await _unitOfWork.Buildings.DeleteAsync(buildingId);
            }
            catch (Exception)
            {
                baseResponse.Success = false;
            }
            return baseResponse;
        }
    }

}
