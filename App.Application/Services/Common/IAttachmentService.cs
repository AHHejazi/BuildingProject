using Application.App.Enum;
using Domain.App.Common;
using Framework.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.App.Services.Common
{
    public interface IAttachmentService
    {
        Task<ReturnResult<Guid>> AddAttachment(AttachmentTypesEnm attachmentType, IFormFile file, string title = null);

        Task<ReturnResult<Attachment>> AddOrUpdateAttachment(
       IFormFile file,
       AttachmentTypesEnm attType,
       Guid? attachmentId = null,
       string title = null);

        Task<Attachment> AddOrUpdateAttachment(
       string fileName,
       string contentType,
       byte[] fileBytes,
       AttachmentTypesEnm attType,
       Guid? attachmentId = null,
       string titleAr = null,
       string titleEn = null,
       string descriptionAr = null,
       string descriptionEn = null,
       int? itemOrder = null);

        Task<Attachment> GetAttachmentForDownloadAsync(Guid? attachmentId);




        public void RemoveRange(List<Guid> deleteIds);



        //get
        List<Attachment> GetRange(List<Guid> ids);



        Task<bool> UpdateAttachmentsTitlesAsync(List<Guid> ids, List<string> titles);

        void DeleteAttachmentFromFileSystem(string fileRelativePath);


        byte[] GenerateThumbnail(byte[] bytes);


        string SaveAttachmentToFileSystem(Attachment attach);


    }
}
