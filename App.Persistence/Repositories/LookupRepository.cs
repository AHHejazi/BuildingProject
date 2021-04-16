﻿using Application.App.Contracts.Persistence;
using Framework.Core.Caching;
using Framework.Core.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly IMemoryCache _cache;
        private readonly BuildingDbContext _dbContext;

        public LookupRepository(IMemoryCache cache, BuildingDbContext dbContext)
        {
            _cache = cache;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SelectListItem>> GetProjectTypeList(CancellationToken cancellationToken = default)
        {
            return await _cache.GetOrCreateAsync(CacheHelpers.GenerateCacheKey("ProjectType"), async entry =>
            {
                entry.SlidingExpiration = CacheHelpers.DefaultCacheDuration;
                var list = await _dbContext.ProjectTypes.ToListAsync(cancellationToken);
                return list.Select(s =>
                     new SelectListItem(
                        CultureHelper.IsArabic ? s.NameAr : s.NameEn, s.Id.ToString())).ToList();
            });

        }

        



        public async Task<IEnumerable<SelectListItem>> GetOutbuildingsTypes()
        {
            return await _cache.GetOrCreateAsync(CacheHelpers.GenerateCacheKey("OutbuildingsTypes"), async entry =>
            {
                entry.SlidingExpiration = CacheHelpers.DefaultCacheDuration;
                var list = await _dbContext.OutbuildingsTypes.ToListAsync();
                return list.Select(s =>
                     new SelectListItem(
                        CultureHelper.IsArabic ? s.NameAr : s.NameEn, s.Id.ToString())).ToList();
            });
        }

    }
}
