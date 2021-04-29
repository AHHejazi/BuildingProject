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
    public class OutbuildingService : IOutbuildingService
    {
        private readonly IMapper _mapper;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        private readonly IUnitOfWork _unitOfWork;


        public OutbuildingService(IMapper mapper, ILogger<OutbuildingDto> logger,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<Guid> AddOutbuilding(OutbuildingDto outbuilding)
        {

            try
            {
                var validator = new OutbuildingValidator(_unitOfWork.Outbuildings);
                var validationResult = await validator.ValidateAsync(outbuilding);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);
                var outbuildingg = _mapper.Map<Outbuilding>(outbuilding);
                outbuildingg.Number = await GenerateOutbuildingNumber();



                outbuildingg = await _unitOfWork.Outbuildings.AddAsync(outbuildingg);
                await _unitOfWork.SaveChangesAsync();
                return outbuildingg.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<string> GenerateOutbuildingNumber()
        {
            var currentYear = DateTime.Now.Year.ToString().Substring(2, 2);
            var currentMonth = DateTime.Now.Month.ToString("d2");

            Expression<Func<Outbuilding, bool>> condtion = r => r.Number.StartsWith($"{currentYear}-{currentMonth}");
            Expression<Func<Outbuilding, string>> orderBy = r => r.Number;


            var lastInsertedOutbuilding = await _unitOfWork.Outbuildings.GenerateModelNumber(condtion, orderBy);

            if (lastInsertedOutbuilding == null)
            {
                return $"{currentYear}-{currentMonth}-0001";
            }

            var currentNo = int.Parse(lastInsertedOutbuilding.Number.Substring(6, 4));
            return $"{currentYear}-{currentMonth}-{(currentNo + 1):d4}";

        }

        public async Task<OutbuildingDto> GetOutbuildingByIdAsync(Guid Id)
        {
            var obj = await _unitOfWork.Outbuildings.GetByIdAsync(Id);
            var retObj = _mapper.Map<OutbuildingDto>(obj);
            return retObj;
        }

        public async Task<OutbuildingVM> SearchOutbuildingAsync(OutbuildingVM outbuildingVM)
        {
            return await _unitOfWork.Outbuildings.SearchAsync(outbuildingVM);
        }



        public async Task UpdateOutbuilding(OutbuildingDto outbuildingDto)
        {

            var outbuilding = _mapper.Map<Outbuilding>(outbuildingDto);
            await _unitOfWork.Outbuildings.UpdateAsync(outbuilding);
            StatusClass = "alert-success";
            Message = "Outbuilding updated successfully.";
            Saved = true;


        }

        public async Task<BaseResponse> DeleteOutbuildingAsync(Guid outbuildingId)
        {
            var baseResponse = new BaseResponse();
            try
            {

                var outbuilding = _unitOfWork.Outbuildings.GetByIdAsync(outbuildingId);

                if (outbuilding == null)
                {
                    throw new NotFoundException(nameof(outbuilding), outbuildingId);
                }

                await _unitOfWork.Outbuildings.DeleteAsync(outbuildingId);
            }
            catch (Exception)
            {
                baseResponse.Success = false;
            }
            return baseResponse;
        }
    }
}
