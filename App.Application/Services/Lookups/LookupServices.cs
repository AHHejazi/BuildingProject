using Application.App.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.App.Services.Lookups
{
    public class LookupServices: ILookupServices
    {
        private readonly ILookupRepository _lookupRepository;
        public LookupServices(ILookupRepository projectRepository)
        {
            _lookupRepository = projectRepository;
        }

        

        public async Task<IEnumerable<SelectListItem>> GetProjectTypeList()
        {
          return await _lookupRepository.GetProjectTypeList();
        }

       
    }
}
