
using Application.App.Contracts.UOW;
using AutoMapper;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.App.Entities.Lookup;
using Microsoft.Extensions.Logging;
using Framework.Core.Exceptions;
using Application.App.Responses;

namespace Application.App.Services.Components
{
    public class ComponentService : IComponentService
    {
        private readonly IMapper _mapper;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        private readonly IUnitOfWork _unitOfWork;


        public ComponentService(IMapper mapper, ILogger<ComponentDto> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<Guid> AddComponent(ComponentDto component)
        {

            try
            {
                var validator = new ComponentValidator(_unitOfWork.Components);
                var validationResult = await validator.ValidateAsync(component);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);
                var Componentt = _mapper.Map<Component>(component);



                Componentt = await _unitOfWork.Components.AddAsync(Componentt);
                await _unitOfWork.SaveChangesAsync();
                return Componentt.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

 
        public async Task<ComponentDto> GetComponentByIdAsync(Guid Id)
        {
            var obj = await _unitOfWork.Components.GetByIdAsync(Id);
            var retObj = _mapper.Map<ComponentDto>(obj);
            return retObj;
        }

        public async Task<ComponentVM> SearchComponentAsync(ComponentVM componentVM)
        {
            return await _unitOfWork.Components.SearchAsync(componentVM);
        }



        public async Task UpdateComponent(ComponentDto componentDto)
        {

            var component = _mapper.Map<Component>(componentDto);
            await _unitOfWork.Components.UpdateAsync(component);
            StatusClass = "alert-success";
            Message = "Component updated successfully.";
            Saved = true;

        }

        public async Task<BaseResponse> DeleteComponentAsync(Guid componentId)
        {
            var baseResponse = new BaseResponse();
            try
            {

                var components = _unitOfWork.Components.GetByIdAsync(componentId);

                if (components == null)
                {
                    throw new NotFoundException(nameof(components), componentId);
                }

                await _unitOfWork.Components.DeleteAsync(componentId);
            }
            catch (Exception)
            {
                baseResponse.Success = false;
            }
            return baseResponse;
        }

        public Task AddBuildingOutbuildings(ComponentDto model)
        {
            throw new NotImplementedException();
        }
    }
}
