using Application.App.Contracts.Persistence;
using Application.App.Contracts.UOW;
using Application.App.Services.Components;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.App.Services.Lookups
{
   
    public class LookupServices : ILookupServices
    {
        private readonly ILookupRepository _lookupRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LookupServices(ILookupRepository projectRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _lookupRepository = projectRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

            public async Task<IEnumerable<SelectListItem>> GetProjectTypeList()
        {
            return await _lookupRepository.GetProjectTypeList();
        }


        public async Task<IEnumerable<SelectListItem>> GetComponentList()
        {
            return await _lookupRepository.GetComponentList();
        }


        public async Task<IEnumerable<SelectListItem>> GetOutbuildingTypeList()
        {
            return await _lookupRepository.GetOutbuildingTypeList();
        }


        public async Task<IEnumerable<SelectListItem>> GetBuildingList()
        {
            return await _lookupRepository.GetBuildingList();
        }

        public async Task<ComponentDto> GetComponentByIdAsync(Guid Id)
        {
            var obj = await _unitOfWork.Components.GetByIdAsync(Id);
            var retObj = _mapper.Map<ComponentDto>(obj);
            return retObj;

        }

    }
}
