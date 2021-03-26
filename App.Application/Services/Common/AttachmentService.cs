using App.Application.Contracts.Persistence;
using Application.App.Enum;
using Domain.App.Common;
using Framework.Core;
using Framework.Core.Extensions;
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
        private readonly IAppSettingsService _appSettingsService;

        public AttachmentService(IAttachmentRepository attachmentRepository,
            IAppSettingsService appSettingsService)
        {
            _attachmentRepository = attachmentRepository;
            _appSettingsService = appSettingsService;
        }


        public async Task<ReturnResult<Guid>> AddAttachment(IFormFile file, string title = null)
        {
            return await _attachmentRepository.AddAttachment(file, title);
        }

        public async Task<ReturnResult<Attachment>> AddOrUpdateAttachment(
            IFormFile file,
            AttachmentTypesEnum attType,
            Guid? attachmentId = null,
            string title = null)
        {
            return await _attachmentRepository.AddOrUpdateAttachmentAsync(file,
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
            return await _attachmentRepository.AddOrUpdateAttachmentAsync(fileName,
             contentType,
            fileBytes,
             attType);
        }

        public async Task<Attachment> GetAttachmentForDownloadAsync(Guid? attachmentId)
        {
            return await _attachmentRepository.GetAttachmentForDownloadAsync(attachmentId);
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
            _attachmentRepository.DeleteAttachmentFromFileSystem(fileRelativePath);
        }

        public byte[] GenerateThumbnail(byte[] bytes)
        {
            return _attachmentRepository.GenerateThumbnail(bytes);
        }

        public string SaveAttachmentToFileSystem(Attachment attach)
        {
            return _attachmentRepository.SaveAttachmentToFileSystem(attach);
        }

    }
}
