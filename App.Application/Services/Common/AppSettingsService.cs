using Application.App.Contracts.Persistence;
using Framework.Core.Globalization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Services.Common
{
    public class AppSettingsService 
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

        #region Props
        #region General Settings

        public string ApplicationUrl { get; set; }
        public string PortalUrl { get; set; }
        public string DateFormat { get; set; }

        public string DateTimeFormat => $"{this.DateFormat} {this.TimeFormat}";

        public int DefaultPagerPageSize { get; set; }
        public string PagerSizeDefaultValues { get; set; }

        public string DownloadFileUrl => "/Files/Download/?attId=";

        public int ExportNoOfItems { get; set; }
        public string TimeFormat { get; set; }

        public string RequestDetailsPageUrl { get; set; }


        #endregion

        #region Attachment Settings

        public int AttachmentsAllowedHeight { get; set; }

        public string AttachmentsAllowedTypes { get; set; }

        public int AttachmentsAllowedWidth { get; set; }

        public int AttachmentsMaxSize { get; set; }

        public string AttachmentsPath { get; set; }

        public bool SaveFilesToDatabase { get; set; }


        #endregion

        #region Notification Settings

        public bool DisableSMSNotifications { get; set; }

        public bool DisableEmailNotifications { get; set; }

        public string ContactUsEmail { get; set; }

        public string EmailSubject => CultureHelper.IsArabic ? this.EmailSubjectAr : this.EmailSubjectEn;

        public string EmailSubjectAr { get; set; }

        public string EmailSubjectEn { get; set; }

        public string EmailFromAddress { get; set; }

        public string EmailFromName { get; set; }


        public string GoogleFCMSenderId { get; set; }

        public string GoogleFCMServerKey { get; set; }

        public bool IsSmtpAuthenticated { get; set; }

        public string SenderId { get; set; }

        public string ServerKey { get; set; }

        public bool SmtpEnableSSL { get; set; }

        public string SmtpPassword { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpServer { get; set; }

        public string SmtpUserName { get; set; }

        public string SmsAppId { get; set; }


        #endregion
        #endregion


    }
}
