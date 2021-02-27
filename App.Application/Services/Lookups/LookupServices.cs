using Application.App.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Lookups
{
    public class LookupServices: ILookupServices
    {
        private readonly ILookupRepository _lookupRepository;
        public LookupServices(ILookupRepository projectRepository)
        {
            _lookupRepository = projectRepository;
        }

        public List<SelectListItem> GetProjectTypeList()
        {
          return  _lookupRepository.GetProjectTypeList();
        }
    }
}
