using Application.App.Enum;
using Application.App.Services.Projects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ComponentsLibrary.UploadFile
{
    public partial class CustomFileUpload<TValue>
    {

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public RenderFragment Control { get; set; }

        [Parameter]
        public int AttachmentType { get; set; }

        [Parameter]
        public Guid? AttachmentId { get; set; }

        [Parameter]
        public Expression<Func<TValue>> For { get; set; }

        [Parameter]
        public EventCallback<FileData> SelectEventCallback { get; set; }


        private async Task OnInputFileChange(InputFileChangeEventArgs e, int AttachmentTypeId)
        {
            FileData fileData = await this.ManageFormFiles(e, AttachmentTypeId);
            
            await SelectEventCallback.InvokeAsync(fileData);
            //fileData.RemoveAll(x => x.AttachemntType == attachmentType);
            //fileData.AddRange(await this.ManageFormFiles(e, attachmentType));
            //Model.fileData = fileData;
            StateHasChanged();
        }


        protected async Task<FileData> ManageFormFiles(InputFileChangeEventArgs e,int AttachmentTypeId)
        {
            var selectedFiles = e.GetMultipleFiles();
            FileData fileData = new FileData();
            foreach (var item in selectedFiles)
            {
                var buffers = new byte[item.Size];
                await item.OpenReadStream().ReadAsync(buffers);
                fileData= new FileData
                {
                    Data = buffers,
                    FileType = item.ContentType,
                    Size = item.Size,
                    AttachemntType = AttachmentTypeId,
                    FileName = item.Name
                };
            }
            return fileData;
        }


    }
}
