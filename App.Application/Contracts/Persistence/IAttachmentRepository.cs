using Application.App.Contracts.Persistence;
using Application.App.Enum;
using Domain.App.Common;
using Framework.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Application.Contracts.Persistence
{
    public interface IAttachmentRepository
    {
        Task<ReturnResult<Guid>> AddAttachment(string attachmentsPath, IFormFile file, string title = null, bool saveToDB = true);
        Task<ReturnResult<Attachment>> AddOrUpdateAttachmentAsync(string attachmentsPath, IFormFile file, AttachmentTypesEnum attType, Guid? attachmentId = null, string title = null, bool saveToDB = true);
        Task<Attachment> AddOrUpdateAttachmentAsync(string attachmentsPath, string fileName, string contentType, byte[] fileBytes, AttachmentTypesEnum attType, Guid? attachmentId = null, string titleAr = null, string titleEn = null, string descriptionAr = null, string descriptionEn = null, int? itemOrder = null, bool saveToDB = true);
        void DeleteAttachmentFromFileSystem(string fileRelativePath, string attachmentsPath);
        byte[] GenerateThumbnail(byte[] bytes);
        Task<Attachment> GetAttachmentForDownloadAsync(Guid? attachmentId, bool saveToDB, string attachmentsPath);
        List<Attachment> GetRange(List<Guid> ids);
        void RemoveRange(List<Guid> deleteIds);
        string SaveAttachmentToFileSystem(Attachment attach, string attachmentsPath);
        Task<bool> UpdateAttachmentsTitlesAsync(List<Guid> ids, List<string> titles);
    }
}
