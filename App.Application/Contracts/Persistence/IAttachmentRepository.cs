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
    public interface IAttachmentRepository : IAsyncRepository<Attachment>
    {
        Task<ReturnResult<Guid>> AddAttachment(IFormFile file, string title = null);

        Task<ReturnResult<Attachment>> AddOrUpdateAttachmentAsync(
       IFormFile file,
       AttachmentTypesEnum attType,
       Guid? attachmentId = null,
       string title = null);

        Task<Attachment> AddOrUpdateAttachmentAsync(
       string fileName,
       string contentType,
       byte[] fileBytes,
       AttachmentTypesEnum attType,
       Guid? attachmentId = null,
       string titleAr = null,
       string titleEn = null,
       string descriptionAr = null,
       string descriptionEn = null,
       int? itemOrder = null);

        Task<Attachment> GetAttachmentForDownloadAsync(Guid? attachmentId);

        public void RemoveRange(List<Guid> deleteIds);

        List<Attachment> GetRange(List<Guid> ids);

        Task<bool> UpdateAttachmentsTitlesAsync(List<Guid> ids, List<string> titles);

        void DeleteAttachmentFromFileSystem(string fileRelativePath);

        byte[] GenerateThumbnail(byte[] bytes);

        string SaveAttachmentToFileSystem(Attachment attach);
    }
}
