using Application.App.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Services.Common
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly IAppSettingRepository _appSettingRepository;

        public AppSettingsService(
            IAppSettingRepository appSettingRepository)
        {
            _appSettingRepository = appSettingRepository;
            LoadSettings();
        }

        public async Task<IDictionary<string, IList<SettingsDto>>> GetAllSettingsCached()
        {
            //cache
            return await _appSettingRepository.GetAllSettingsCached();
        }

        public async Task<List<SettingsDto>> GetSettingsByGroup(string groupName)
        {
            return await _appSettingRepository.GetSettingsByGroup(groupName);
        }



        public async Task<SettingsDto> GetSetting(string key)
        {
            return await _appSettingRepository.GetSetting(key);
        }


        public async Task<T> GetValue<T>(string key, T defaultValue = default(T))
        {
            return await _appSettingRepository.GetValue<T>(key);
        }

        public void LoadSettings()
        {

            _appSettingRepository.LoadSettings();

        }


    }
}
