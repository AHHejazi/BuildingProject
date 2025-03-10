﻿using Application.App.Contracts.Persistence;
using Application.App.Services.Common;
using Domain.App.Common;
using Framework.Core;
using Framework.Core.Caching;
using Framework.Core.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class AppSettingRepository : BaseRepository<SystemSetting>, IAppSettingRepository
    {
        private readonly IMemoryCache _cache;

        public AppSettingRepository(IMemoryCache cache, BuildingDbContext dbContext):base(dbContext)
        {
            _cache = cache;
        }

        public async Task<IDictionary<string, IList<SettingsDto>>> GetAllSettingsCached()
        {
            //cache
            return await _cache.GetOrCreateAsync(CacheHelpers.GenerateCacheKey("SettingsAllCacheKey"), async entry =>
            {
                //we use no tracking here for performance optimization
                //anyway records are loaded only for read-only operations
                entry.SlidingExpiration = CacheHelpers.DefaultCacheDuration;
                var query = from s in _dbContext.SystemSettings
                            orderby s.Name
                            select s;
                var settings = await query.AsNoTracking().Select(s => new SettingsDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Value = s.Value,
                    GroupName = s.GroupName,
                    ValueType = s.ValueType
                }).ToListAsync();

                var dictionary = new Dictionary<string, IList<SettingsDto>>();
                foreach (var s in settings)
                {
                    var resourceName = s.Name.ToLowerInvariant();


                    if (!dictionary.ContainsKey(resourceName))
                    {
                        //first setting
                        dictionary.Add(resourceName, new List<SettingsDto>
                        {
                            s
                        });
                    }
                    else
                    {
                        //already added
                        //most probably it's the setting with the same name but for some certain store (storeId > 0)
                        dictionary[resourceName].Add(s);
                    }
                }

                return dictionary;
            });
        }

        public async Task<List<SettingsDto>> GetSettingsByGroup(string groupName)
        {
            var list = new List<SettingsDto>();

            var allSetting = await GetAllSettingsCached();

            foreach (var setting in allSetting)
            {
                var item = setting.Value.Where(a => a.GroupName == groupName);
                list.AddRange(item.ToList());
            }

            return list;
        }



        public async Task<SettingsDto> GetSetting(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            var settings = await GetAllSettingsCached();
            key = key.Trim().ToLowerInvariant();
            if (!settings.ContainsKey(key))
                return null;

            var settingsByKey = settings[key];
            var setting = settingsByKey.FirstOrDefault(x => x.Name.ToLowerInvariant() == key);

            return setting;
        }



        public async Task<T> GetValue<T>(string key, T defaultValue = default(T))
        {
            if (string.IsNullOrEmpty(key))
                return defaultValue;

            var settings = await GetAllSettingsCached();
            key = key.Trim().ToLowerInvariant();
            if (!settings.ContainsKey(key))
                return defaultValue;

            var settingsByKey = settings[key];
            var setting = settingsByKey.FirstOrDefault(x => x.Name.ToLowerInvariant() == key);


            return setting != null ? CommonHelper.To<T>(setting.Value) : defaultValue;
        }

        public async void LoadSettings()
        {

            foreach (var prop in this.GetType().GetProperties())
            {
                // get properties we can read and write to
                if (!prop.CanRead || !prop.CanWrite)
                    continue;

                var key = prop.Name;

                var setting = await GetValue<string>(key);
                if (setting == null)
                    continue;

                if (!TypeDescriptor.GetConverter(prop.PropertyType).CanConvertFrom(typeof(string)))
                    continue;

                if (!TypeDescriptor.GetConverter(prop.PropertyType).IsValid(setting))
                    continue;

                var value = TypeDescriptor.GetConverter(prop.PropertyType).ConvertFromInvariantString(setting);

                //set property
                prop.SetValue(this, value);
            }

        }

    }
}
