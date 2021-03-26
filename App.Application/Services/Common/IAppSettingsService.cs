using Framework.Core.Globalization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Services.Common
{
    public interface IAppSettingsService
    {
        Task<IDictionary<string, IList<SettingsDto>>> GetAllSettingsCached();
        Task<List<SettingsDto>> GetSettingsByGroup(string groupName);
        Task<SettingsDto> GetSetting(string key);
        Task<T> GetValue<T>(string key, T defaultValue = default(T));


    }
}
