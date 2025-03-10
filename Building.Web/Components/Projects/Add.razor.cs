﻿using Application.App.Enum;
using Application.App.Services.Lookups;
using Application.App.Services.Projects;
using ComponentsLibrary.PopUp;
using GeneralIdentity.App.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
        public ProjectDto Model { get; set; } = new();
        private IEnumerable<SelectListItem> ProjectTypeList;
        private EditContext editContext;


        protected async override Task OnInitializedAsync()
        {
            ProjectTypeList = await _lookupServices.GetProjectTypeList();
            editContext = new EditContext(Model);
        }



        private async Task SubmitProjectAsync()
        {
            try
            {
                await _projectService.AddProject(Model);
                StatusClass = "alert alert-success";
                Message = "New Project added successfully.";
            }
            catch (Exception)
            {

                StatusClass = "alert alert-danger";
                Message = "Something went wrong adding the new Project. Please try again.";

            }

        }

        public void ValidateForm(EditContext editContext)
        {

            var isValid = editContext.Validate();

            if (!isValid)
                return;

        }

        protected MapDialog MapDialog { get; set; }
        protected void QuickShowMap()
        {
            MapDialog.Show();
        }

        protected void MapDialog_OnDialogClose(string location)
        {
            if (!string.IsNullOrEmpty(location))
            {
                var coordination = location.Split(',');

                Model.PropertyLatitude = coordination[0];
                Model.PropertyLongitude = coordination[1];
            }

            StateHasChanged();
        }
    }
}
