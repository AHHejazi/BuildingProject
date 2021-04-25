using Application.App.Enum;
using Application.App.Services.Projects;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Building.Web.Components.Projects
{
    public partial class ProjectDiagrams : PageBase
    {
        [Inject]
        private IProjectService _projectService { get; set; }

        List<FileData> fileData = new List<FileData>();

        [Parameter]
        public Guid Id { get; set; }

        public ProjectDiagramsDto Model { get; set; } = new();



        protected override async Task OnInitializedAsync()
        {
            var retObj =await _projectService.GetProjectByIdAsync(Id);
            Model.InstrumentAttachmentId = retObj.InstrumentAttachmentId;
        }


        private async Task SubmitProjectDiagramAsync()
        {
                await _projectService.AddProjectDiagramAsync(Model);
                StatusClass = "alert alert-success";
                Message = "New Project added successfully.";
            
        }

        public void ValidateForm(EditContext editContext)
        {

            var isValid = editContext.Validate();

            if (!isValid)
                return;

        }


        private async Task OnInputFileChange(InputFileChangeEventArgs e, int attachmentTypeId)
        {
            fileData.RemoveAll(x => x.AttachemntType == attachmentTypeId);
            fileData.AddRange(await this.ManageFormFiles(e, attachmentTypeId));
            Model.ConstructionDiagramId = Guid.NewGuid();
            Model.fileData = fileData;
            StateHasChanged();
        }


        protected void UpdateFileDate(FileData fileDataObj)
        {
            fileData.RemoveAll(x => x.AttachemntType == fileDataObj.AttachemntType);
            fileData.Add(fileDataObj);
            Model.fileData = fileData;
            StateHasChanged();
        }

    }
}
