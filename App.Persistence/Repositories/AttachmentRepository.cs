using App.Application.Contracts.Persistence;
using Application.App.Contracts.Persistence;
using Application.App.Enum;
// why there is a choice to use .net.mail
using Domain.App.Common;
using Framework.Core;
using Framework.Core.Extensions;
using Localization.App;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
    {
        private readonly BuildingDbContext _dbContext;
        private readonly IAppSettingRepository _iAppSettingRepository;

        public AttachmentRepository(IMemoryCache cache, BuildingDbContext dbContext,
            IAppSettingRepository iAppSettingRepository) : base(dbContext)
        {
            _dbContext = dbContext;
            _iAppSettingRepository = iAppSettingRepository;
        }

        public async Task<Attachment> GetAttachmentForDownloadAsync(Guid? attachmentId)
        {
            var attachment = await _dbContext.Attachments.AsNoTracking().Where(at => at.Id == attachmentId).Include(c => c.AttachmentContent)
                .AsNoTracking().SingleOrDefaultAsync();

            if (await _iAppSettingRepository.GetValue<bool>("SaveFilesToDatabase") && attachment?.AttachmentContent.FileContent != null)
            {
                return attachment;
            }

            if (string.IsNullOrEmpty(await _iAppSettingRepository.GetValue<string>("AttachmentsPath"))
                || string.IsNullOrEmpty(attachment?.FilePath))
            {
                return attachment;
            }

            var filePath = $"{_iAppSettingRepository.GetValue<string>("AttachmentsPath")}{attachment.FilePath}";
            if (File.Exists(filePath))
            {
                attachment.AttachmentContent.FileContent = File.ReadAllBytes(filePath);
            }

            return attachment;
        }

        public void RemoveRange(List<Guid> deleteIds)
        {
            var attchRnag = this._dbContext.Attachments.Where(a => deleteIds.Contains(a.Id));
            if (attchRnag != null)
            {

                this._dbContext.Attachments.RemoveRange();
            }
        }

        public List<Attachment> GetRange(List<Guid> ids)
        {
            return this._dbContext.Attachments.AsNoTracking().Where(a => ids.Contains(a.Id)).ToList();
        }

        public async Task<bool> UpdateAttachmentsTitlesAsync(List<Guid> ids, List<string> titles)
        {
            if (ids.IsNullOrEmpty())
                return false;

            var attachments = await _dbContext.Attachments
                              .Where(a => ids.Contains(a.Id))
                              .OrderBy(a => a.Id)
                              .ToListAsync();

            if (attachments.Count != ids.Count)
                return false;

            for (int i = 0; i < ids.Count; i++)
            {
                for (int j = 0; j < attachments.Count; j++)
                {
                    Attachment attachment = attachments[j];
                    if (ids[i] == attachment.Id)
                    {
                        attachment.TitleEn = titles[i];
                        await this.UpdateAsync(attachment);
                    }
                }
            }

            return true;
        }
        public void DeleteAttachmentFromFileSystem(string fileRelativePath)
        {
            if (string.IsNullOrEmpty(fileRelativePath))
            {
                return;
            }

            var filePath = $@"{_iAppSettingRepository.GetValue<string>("AttachmentsPath")}{fileRelativePath}";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public byte[] GenerateThumbnail(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                var thumb = new Bitmap(100, 100);
                using (var bmp = Image.FromStream(ms))
                {
                    using (var g = Graphics.FromImage(thumb))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawImage(bmp, 0, 0, 100, 100);
                    }
                }

                using (var msWrite = new MemoryStream())
                {
                    thumb.Save(msWrite, ImageFormat.Png);
                    return msWrite.ToArray();
                }
            }
        }

        public string SaveAttachmentToFileSystem(Attachment attach)
        {
            var relativeFolderPath = $"\\{DateTime.Now.Year}\\{DateTime.Now.Month}\\{DateTime.Now.Day}";
            var fullFolderPath = $"{ _iAppSettingRepository.GetValue<string>("AttachmentsPath")}{relativeFolderPath}";
            var fileName = attach.Id + attach.Extension;
            var fileRelativePath = $@"{relativeFolderPath}\{fileName}";

            if (!Directory.Exists(fullFolderPath))
            {
                Directory.CreateDirectory(fullFolderPath);
            }

            using (var bw = new BinaryWriter(File.Open(Path.Combine(fullFolderPath, fileName), FileMode.OpenOrCreate)))
            {
                bw.Write(attach.AttachmentContent.FileContent);
            }

            return fileRelativePath;
        }

        public async Task<ReturnResult<Guid>> AddAttachment(IFormFile file, string title = null)
        {
            var result = new ReturnResult<Guid>();
            var attResult = await this.AddOrUpdateAttachmentAsync(file, AttachmentTypesEnum.GeneralFileAttachment, null, title);
            if (!attResult.IsValid)
            {
                result.Merge(attResult);
                return result;
            }

            result.Value = attResult.Value.Id;
            return result;
        }

        public async Task<ReturnResult<Attachment>> AddOrUpdateAttachmentAsync(
            IFormFile file,
            AttachmentTypesEnum attType,
            Guid? attachmentId = null,
            string title = null)
        {
            var result = new ReturnResult<Attachment>();
            if (file == null)
            {
                result.AddErrorItem(string.Empty, CommonResources.FileZeroLengthErrorMessage);
                return result;
            }

            if (file.Length <= 0)
            {
                result.AddErrorItem(string.Empty, CommonResources.FileZeroLengthErrorMessage);
                return result;
            }
            var retbool = await _iAppSettingRepository.GetValue<bool>("SaveFilesToDatabase");
            if (retbool
                && string.IsNullOrEmpty(await _iAppSettingRepository.GetValue<string>("AttachmentsPath")))
            {
                throw new Exception(
                    "File can not be saved. Current Settings is. SaveFileToDatabase=true and Attachment Path is Missing");
            }

            var fileBytes = new byte[file.Length];

            ////file.InputStream.Read(fileBytes, 0, file.Length);
            var ms = new MemoryStream();
            file.OpenReadStream().CopyTo(ms);

            result.Value = await this.AddOrUpdateAttachmentAsync(
                file.FileName,
                file.ContentType,
                ms.ToArray(),
                attType,
                attachmentId,
                null,
                title);
            return result;
        }

        public async Task<Attachment> AddOrUpdateAttachmentAsync(
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
            var isUpdateFile = attachmentId.HasValue && attachmentId.Value != Guid.Empty;

            var attachment = isUpdateFile
                                 ? await this.GetByIdAsync(attachmentId.Value)
                                 : new Attachment { Id = Guid.NewGuid().AsSequentialGuid() };

            if (attachment == null)
            {
                throw new Exception("The Attachment File You are trying to update Does Not Exist in the database");
            }

            if (attachment.AttachmentContent == null)
            {
                attachment.AttachmentContent = new AttachmentContent();
            }

            attachment.AttachmentContent.FileContent = fileBytes;

            attachment.TitleAr = titleAr;
            attachment.TitleEn = titleEn;
            attachment.DescriptionAr = descriptionAr ?? attachment.DescriptionAr;
            attachment.DescriptionEn = descriptionEn ?? attachment.DescriptionEn;
            attachment.ContentType = contentType;
            attachment.Extension = new FileInfo(fileName).Extension;
            attachment.FileName = fileName;
            attachment.AttachmentTypeId = (int)attType;
            if (contentType.StartsWith("image/"))
                attachment.Thumbnail = this.GenerateThumbnail(fileBytes);

            // in updating delete old file
            if (isUpdateFile)
            {
                this.DeleteAttachmentFromFileSystem(attachment.FilePath);
            }
            var retbool = await _iAppSettingRepository.GetValue<bool>("SaveFilesToDatabase");
            attachment.FilePath = retbool
                                      ? null
                                      : this.SaveAttachmentToFileSystem(attachment);
            attachment.AttachmentContent.Id = attachment.Id;
            attachment.AttachmentContent.FileContent =
                retbool ? fileBytes : null;

            if (!isUpdateFile)
            {
                await _dbContext.AddAsync(attachment);
            }

            return attachment;
        }

    }
}
