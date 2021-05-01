using Application.App.Contracts.UOW;
using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Framework.Core.Exceptions;
using Application.App.Responses;
using Domain.App.Entities;

namespace Application.App.Services.BuildingOuts
{
    public class BuildingOutService : IBuildingOutService
    {
        private readonly IMapper _mapper;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        private readonly IUnitOfWork _unitOfWork;


        public BuildingOutService(IMapper mapper, ILogger<BuildingOutDto> logger,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<Guid> AddBuildingOutAsync(BuildingOutDto buildingOut)
        {

            try
            {
                var validator = new BuildingOutValidator(_unitOfWork.BuildingOuts);
                var validationResult = await validator.ValidateAsync(buildingOut);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);
                var ob = _mapper.Map<BuildingOut>(buildingOut);



                ob = await _unitOfWork.BuildingOuts.AddAsync(ob);
                await _unitOfWork.SaveChangesAsync();
                return ob.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<BuildingOutDto> GetBuildingOutByIdAsync(int Id)
        {
            var obj = await _unitOfWork.BuildingOuts.GetByIdAsync(Id);
            var retObj = _mapper.Map<BuildingOutDto>(obj);
            return retObj;
        }



        public async Task UpdateBuildingOutAsync(BuildingOutDto buildingOutDto)
        {

            var buildingOut = _mapper.Map<BuildingOut>(buildingOutDto);
            await _unitOfWork.BuildingOuts.UpdateAsync(buildingOut);
            StatusClass = "alert-success";
            Message = "Building Outbuilding updated successfully.";
            Saved = true;


        }

        public async Task<BaseResponse> DeleteBuildingOutAsync(Guid buildingOutId)
        {
            var baseResponse = new BaseResponse();
            try
            {

                var buildingOut = _unitOfWork.BuildingOuts.GetByIdAsync(buildingOutId);

                if (buildingOut == null)
                {
                    throw new NotFoundException(nameof(buildingOut), buildingOutId);
                }

                await _unitOfWork.BuildingOuts.DeleteAsync(buildingOutId);
            }
            catch (Exception)
            {
                baseResponse.Success = false;
            }
            return baseResponse;
        }
    }
}
