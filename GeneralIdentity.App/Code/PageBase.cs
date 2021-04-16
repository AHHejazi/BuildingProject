using Application.App.Contracts.UOW;
using Application.App.Enum;
using Application.App.Services.Projects;
using Domain.App.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralIdentity.App.Code
{
    public class PageBase : ComponentBase
    {
       

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected async Task<List<FileData>> ManageFormFiles(InputFileChangeEventArgs e, AttachmentTypesEnum attachemntType)
        {
           var selectedFiles = e.GetMultipleFiles();
            List<FileData> fileData = new List<FileData>();
            foreach (var item in selectedFiles)
            {
                var buffers = new byte[item.Size];
                await item.OpenReadStream().ReadAsync(buffers);
                fileData.Add(new FileData
                {
                    Data = buffers,
                    FileType = item.ContentType,
                    Size = item.Size,
                    AttachemntType = attachemntType,
                    FileName= item.Name
                });
            }
            return fileData;
        }
    }



}
