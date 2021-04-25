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

namespace Application.App.Services.Supplies
{
    public class SuppliesService : ISuppliesService
    {
        private readonly IMapper _mapper;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        private readonly IUnitOfWork _unitOfWork;
        

        public SuppliesService(IMapper mapper, ISuppliesRepository suppliesRepository, ILogger<SuppliesDto> logger,
        IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<Guid> AddSupply(SuppliesDto supply)
        {

            try
            {
                var validator = new SuppliesValidator(_unitOfWork.Suppliess);
                var validationResult = await validator.ValidateAsync(supply);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);
                var suppli = _mapper.Map<Supplement>(supply);
                suppli.Number = GenerateSuppliesNumber();



                suppli = await _unitOfWork.Suppliess.AddAsync(suppli);
                await _unitOfWork.SaveChangesAsync();
                return suppli.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public string GenerateSuppliesNumber()
        {
            var currentYear = DateTime.Now.Year.ToString().Substring(2, 2);
            var currentMonth = DateTime.Now.Month.ToString("d2");

            Expression<Func<Supplement, bool>> condtion = r => r.Number.StartsWith($"{currentYear}-{currentMonth}");
            Expression<Func<Supplement, string>> orderBy = r => r.Number;


            var lastInsertedSupply = _unitOfWork.Suppliess.GenerateModelNumber(condtion, orderBy);

            if (lastInsertedSupply == null)
            {
                return $"{currentYear}-{currentMonth}-0001";
            }

            var currentNo = int.Parse(lastInsertedSupply.Number.Substring(6, 4));
            return $"{currentYear}-{currentMonth}-{(currentNo + 1):d4}";

        }

        public async Task<SuppliesDto> GetSuppliesByIdAsync(Guid Id)
        {
            var obj = await _unitOfWork.Suppliess.GetByIdAsync(Id);
            var retObj = _mapper.Map<SuppliesDto>(obj);
            return retObj;
        }

        public async Task<SuppliesVM> SearchSuppliesAsync(SuppliesVM suppliesVM)
        {
            return await _unitOfWork.Suppliess.SearchAsync(suppliesVM);
        }



        public async Task UpdateSupply(SuppliesDto supplyDto)
        {
            
                var supply = _mapper.Map<Supplement>(supplyDto);
                await _unitOfWork.Suppliess.UpdateAsync(supply);
            
        }

        public async Task<BaseResponse> DeleteSuppliesAsync(Guid supplyId)
        {
            var baseResponse = new BaseResponse();
            try
            {
                
                var supplies = _unitOfWork.Suppliess.GetByIdAsync(supplyId);

                if (supplies == null)
                {
                    throw new NotFoundException(nameof(supplies), supplyId);
                }

                await _unitOfWork.Suppliess.DeleteAsync(supplyId);
            }
            catch (Exception)
            {
                baseResponse.Success = false;
            }
            return baseResponse;
        }
    }
}
