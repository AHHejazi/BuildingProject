using Application.App.Enum;
using Application.App.Services.Lookups;
using Application.App.Services.Projects;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Building.Web.Components.Projects
{
    public partial class Add : PageBase
    {
        [Inject]
        private IProjectService _projectService { get; set; }
        [Inject]
        private ILookupServices _lookupServices { get; set; }

        [Parameter]
        public EventCallback<ProjectDto> OnValidSubmit { get; set; }
        public ProjectDto Model = new ProjectDto();
        private IEnumerable<SelectListItem> ProjectTypeList;
        private EditContext editContext;
        List<FileData> fileData = new List<FileData>();
        
        

        protected async override Task OnInitializedAsync()
        {
            ProjectTypeList = await _lookupServices.GetProjectTypeList();
            editContext = new EditContext(Model);
        }

        private async Task OnInputFileChange(InputFileChangeEventArgs e, AttachmentTypesEnum attachmentType)
        {
            fileData.RemoveAll(x => x.AttachemntType == attachmentType);
            fileData.AddRange(await this.ManageFormFiles(e, attachmentType));
            StateHasChanged();
        }

        private async Task SubmitProjectAsync()
        {
            var isValid = editContext.Validate();

            if (isValid)
            {
                Model.fileData = fileData;
                var retObjid = await _projectService.AddProject(Model);
                StatusClass = "alert alert-success";
                Message = "New Project added successfully.";
            }
            else
            {
                StatusClass = "alert alert-danger";
                Message = "Something went wrong adding the new Project. Please try again.";
            }
        }

        public async Task ValidateForm(EditContext editContext)
        {

            var isValid = editContext.Validate();

            if (!isValid)
                return;

        }
    }
}
