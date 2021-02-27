using Application.App.Contracts.Persistence;
using Framework.Core.Caching;
using Framework.Core.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace App.Persistence.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly ICacheManager _cacheManager;
        private readonly BuildingDbContext _dbContext;

        public LookupRepository(ICacheManager cacheManager, BuildingDbContext dbContext)
        {
            _cacheManager = cacheManager;
            _dbContext = dbContext;
        }


        public List<SelectListItem> GetProjectTypeList()
        {
          return  _dbContext.ProjectTypes.AsNoTracking().Select(s =>
                    new SelectListItem(
                       CultureHelper.IsArabic ? s.NameAr : s.NameEn, s.Id.ToString())).ToList();
        }

    }
}
