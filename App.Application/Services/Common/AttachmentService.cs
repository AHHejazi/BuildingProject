using App.Application.Contracts.Persistence;
using Application.App.Enum;
using Domain.App.Common;
using Framework.Core;
using Framework.Core.Extensions;
using Framework.Core.Globalization;
using Localization.App;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.App.Services.Common
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly AppSettingsService _appSettingsService;


        public AttachmentService(IAttachmentRepository attachmentRepository,
            AppSettingsService appSettingsService)
        {
            _attachmentRepository = attachmentRepository;
            _appSettingsService = appSettingsService;
        }


        public async Task<ReturnResult<Guid>> AddAttachment(IFormFile file, string title = null)
        {
           
            return await _attachmentRepository.AddAttachment(_appSettingsService.AttachmentsPath, file, title);
        }

        public async Task<ReturnResult<Attachment>> AddOrUpdateAttachment(
            IFormFile file,
            AttachmentTypesEnum attType,
            Guid? attachmentId = null,
            string title = null)
        {
            return await _attachmentRepository.AddOrUpdateAttachmentAsync(_appSettingsService.AttachmentsPath, file,
             attType);
        }

        public async Task<Attachment> AddOrUpdateAttachment(
            string fileName,
            string contentType,
            byte[] fileBytes,
            AttachmentTypesEnum attType,
            Guid? attachmentId = null,
            string titleAr = null,
            string titleEn = null,
            string descriptionAr = null,
            string descriptionEn = null,
            int? itemOrder = null)
        {
            return await _attachmentRepository.AddOrUpdateAttachmentAsync(_appSettingsService.AttachmentsPath, fileName,
             contentType,
            fileBytes,
             attType);
        }

        public async Task<Attachment> GetAttachmentForDownloadAsync(Guid? attachmentId)
        {
            return await _attachmentRepository.GetAttachmentForDownloadAsync(attachmentId, _appSettingsService.SaveFilesToDatabase, _appSettingsService.AttachmentsPath);
        }

        public void RemoveRange(List<Guid> deleteIds)
        {
            _attachmentRepository.RemoveRange(deleteIds);
        }

        public List<Attachment> GetRange(List<Guid> ids)
        {
            return _attachmentRepository.GetRange(ids);
        }


        public async Task<bool> UpdateAttachmentsTitlesAsync(List<Guid> ids, List<string> titles)
        {
            return await _attachmentRepository.UpdateAttachmentsTitlesAsync(ids, titles);
        }

        public void DeleteAttachmentFromFileSystem(string fileRelativePath)
        {
            _attachmentRepository.DeleteAttachmentFromFileSystem(fileRelativePath, _appSettingsService.AttachmentsPath);
        }

        public byte[] GenerateThumbnail(byte[] bytes)
        {
            return _attachmentRepository.GenerateThumbnail(bytes);
        }

        public string SaveAttachmentToFileSystem(Attachment attach)
        {
            return _attachmentRepository.SaveAttachmentToFileSystem(attach, _appSettingsService.AttachmentsPath);
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
