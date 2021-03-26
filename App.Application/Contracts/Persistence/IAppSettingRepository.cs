using Application.App.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Contracts.Persistence
{
    public interface IAppSettingRepository
    {
        Task<IDictionary<string, IList<SettingsDto>>> GetAllSettingsCached();
        Task<List<SettingsDto>> GetSettingsByGroup(string groupName);
        Task<SettingsDto> GetSetting(string key);
        Task<T> GetValue<T>(string key, T defaultValue = default(T));
        void LoadSettings();


    }
}
