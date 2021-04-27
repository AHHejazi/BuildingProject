using Application.App.Contracts.Persistence;
using Application.App.Contracts.UOW;
using Application.App.Enum;
using Application.App.Responses;
using Application.App.Services.Common;
using AutoMapper;
using Domain.App.Entities;
using Framework.Core.Exceptions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.App.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettingsService _appSettingsService;

        public ProjectService(IMapper mapper, IUnitOfWork unitOfWork, AppSettingsService appSettingsService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appSettingsService = appSettingsService;
        }

        
        public async Task<Guid> AddProject(ProjectDto project)
        {
            var validator = new ProjectValidator(_unitOfWork.Projects);
            var validationResult = await validator.ValidateAsync(project);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            var prject = _mapper.Map<Project>(project);
            prject.Number = await GenerateProjectNumber();
            prject = await _unitOfWork.Projects.AddAsync(prject);
            await _unitOfWork.SaveChangesAsync();
            return prject.Id;

        }

        public async Task<string> GenerateProjectNumber()
        {
            var currentYear = DateTime.Now.Year.ToString().Substring(2, 2);
            var currentMonth = DateTime.Now.Month.ToString("d2");

            Expression<Func<Project, bool>> condtion = r => r.Number.StartsWith($"{currentYear}-{currentMonth}");
            Expression<Func<Project, string>> orderBy = r => r.Number;


            var lastInsertedProject = await _unitOfWork.Projects.GenerateModelNumber(condtion, orderBy);

            if (lastInsertedProject == null)
            {
                return $"{currentYear}-{currentMonth}-0001";
            }

            var currentNo = int.Parse(lastInsertedProject.Number.Substring(6, 4));
            return $"{currentYear}-{currentMonth}-{(currentNo + 1):d4}";
        }

        public async Task<BaseResponse> DeleteProjectAsync(Guid projectId)
        {
            var baseResponse = new BaseResponse();
            var isHasRelatedbuiding = await _unitOfWork.Buildings.CheckRelatedBuildingAsync(projectId);

            if (isHasRelatedbuiding)
            {
                baseResponse.Success = false;
                baseResponse.Message = "Project already related with building project " +
                    "you have to delete realted project before";
                return baseResponse;
            }
            var project = _unitOfWork.Projects.GetByIdAsync(projectId);

            if (project == null)
            {
                throw new NotFoundException(nameof(project), projectId);
            }

            await _unitOfWork.Projects.DeleteAsync(projectId);
            return baseResponse;
        }

        public async Task<ProjectDto> GetProjectByIdAsync(Guid Id)
        {
            var obj = await _unitOfWork.Projects.GetByIdAsync(Id);
            var retObj = _mapper.Map<ProjectDto>(obj);
            return retObj;

        }

        public async Task<IReadOnlyList<Project>> ProjectListQuery()
        {
            var result = await _unitOfWork.Projects.ListAllAsync();
            return result;
        }


        public async Task<ProjectVM> SearchProjectsAsync(ProjectVM projectVM)
        {
            return await _unitOfWork.Projects.SearchAsync(projectVM);
        }



        public async Task UpdateProject(ProjectDto project)
        {
            await _unitOfWork.Projects.UpdateAsync(project);
            StatusClass = "alert-success";
            Message = "Project updated successfully.";
            Saved = true;
        }

        public async Task<IEnumerable<SelectListItem>> ProjectListByCurrentUserAsync(string userName = null)
        {
            return await _unitOfWork.Projects.ProjectListByCurrentUserAsync(userName);
        }

        public async Task<Guid> AddProjectDiagramAsync(ProjectDiagramsDto model)
        {

            var validator = new ProjectDiagramsValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if (model.fileData != null && model.fileData.Count() > 0)
            {
                foreach (var item in model.fileData)
                {
                    var retAttachmentId = await _unitOfWork.Attachments.AddOrUpdateAttachmentAsync(_appSettingsService.AttachmentsPath, item.FileName, item.FileType, item.Data, (AttachmentTypesEnm)item.AttachemntType);

                }
                _unitOfWork.SaveChangesAsync();
            }

            return Guid.Empty;
        }
    }
}
