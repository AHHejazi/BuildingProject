using App.Application.Contracts.Persistence;
using Application.App.Contracts.UOW;
using AutoMapper;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.App.Entities.Lookup;
using Microsoft.Extensions.Logging;
using Framework.Core.Exceptions;
using Application.App.Responses;
using Domain.App.Entities;

namespace Application.App.Services.Outbuildings
{
    public class OutbuildingTypeService : IOutbuildingTypeService
    {
        private readonly IMapper _mapper;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        private readonly IUnitOfWork _unitOfWork;


        public OutbuildingTypeService(IMapper mapper, ILogger<OutbuildingTypeDto> logger,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<Guid> AddOutbuildingTypeAsync(OutbuildingTypeDto outbuildingtype)
        {

            try
            {
                var validator = new OutbuildingTypeValidator(_unitOfWork.OutbuildingType);
                var validationResult = await validator.ValidateAsync(outbuildingtype);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);
                var ob = _mapper.Map<OutbuildingsType>(outbuildingtype);



                ob = await _unitOfWork.OutbuildingType.AddAsync(ob);
                await _unitOfWork.SaveChangesAsync();
                return ob.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<OutbuildingTypeDto> GetOutbuildingTypeByIdAsync(int Id)
        {
            var obj = await _unitOfWork.OutbuildingType.GetByIdAsync(Id);
            var retObj = _mapper.Map<OutbuildingTypeDto>(obj);
            return retObj;
        }

        public async Task<OutbuildingTypeVM> SearchOutbuildingTypeAsync(OutbuildingTypeVM outbuildingVM)
        {
            return await _unitOfWork.OutbuildingType.SearchAsync(outbuildingVM);
        }



        public async Task UpdateOutbuildingTypeAsync(OutbuildingTypeDto outbuildingDto)
        {

            var outbuilding = _mapper.Map<OutbuildingsType>(outbuildingDto);
            await _unitOfWork.OutbuildingType.UpdateAsync(outbuilding);
            StatusClass = "alert-success";
            Message = "Outbuilding updated successfully.";
            Saved = true;


        }

        public async Task<BaseResponse> DeleteOutbuildingTypeAsync(Guid outbuildingId)
        {
            var baseResponse = new BaseResponse();
            try
            {

                var outbuilding = _unitOfWork.OutbuildingType.GetByIdAsync(outbuildingId);

                if (outbuilding == null)
                {
                    throw new NotFoundException(nameof(outbuilding), outbuildingId);
                }

                await _unitOfWork.OutbuildingType.DeleteAsync(outbuildingId);
            }
            catch (Exception)
            {
                baseResponse.Success = false;
            }
            return baseResponse;
        }
    }
}
