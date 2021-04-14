using Application.App.Contracts.Persistence;
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
        private readonly IProjectRepository _projectRepository;
        private readonly IBuildingRepository _buildingRepository;

        private readonly IMapper _mapper;
        private readonly ILogger<ProjectDto> _logger;
        private readonly IAttachmentService _attachmentService;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        public ProjectService(IMapper mapper, IProjectRepository projectRepository, ILogger<ProjectDto> logger, IAttachmentService attachmentService,
            IBuildingRepository buildingRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _logger = logger;
            _attachmentService = attachmentService;
            _buildingRepository = buildingRepository;
        }


        public async Task<Guid> AddProject(ProjectDto project)
        {
            try
            {
                var validator = new ProjectValidator(_projectRepository);
                var validationResult = await validator.ValidateAsync(project);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);
                var prject = _mapper.Map<Project>(project);
                prject.Number = GenerateProjectNumber();

                if (project.fileData != null && project.fileData.Count() > 0)
                {
                    foreach (var item in project.fileData)
                    {
                        var retAttachmentId = await _attachmentService.AddOrUpdateAttachment(item.FileName, item.FileType, item.Data, item.AttachemntType);
                    }
                }

                prject = await _projectRepository.AddAsync(prject);
                return prject.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string GenerateProjectNumber()
        {
            var currentYear = DateTime.Now.Year.ToString().Substring(2, 2);
            var currentMonth = DateTime.Now.Month.ToString("d2");

            Expression<Func<Project, bool>> condtion = r => r.Number.StartsWith($"{currentYear}-{currentMonth}");
            Expression<Func<Project, string>> orderBy = r => r.Number;


            var lastInsertedProject = _projectRepository.GenerateModelNumber(condtion, orderBy);

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
            var isHasRelatedbuiding = await _buildingRepository.CheckRelatedBuildingAsync(projectId);

            if (isHasRelatedbuiding)
            {
                baseResponse.Success = false;
                baseResponse.Message = "Project already related with building project " +
                    "you have to delete realted project before";
                return baseResponse;
            }
            var project = _projectRepository.GetByIdAsync(projectId);

            if (project == null)
            {
                throw new NotFoundException(nameof(project), projectId);
            }

            await _projectRepository.DeleteAsync(projectId);
            return baseResponse;
        }

        public async Task<ProjectDto> GetProjectByIdAsync(Guid Id)
        {
            var obj = await _projectRepository.GetByIdAsync(Id);
            var retObj = _mapper.Map<ProjectDto>(obj);
            return retObj;

        }

        public async Task<IReadOnlyList<Project>> ProjectListQuery()
        {
            var result = await _projectRepository.ListAllAsync();
            return result;
        }


        public async Task<ProjectVM> SearchProjectsAsync(ProjectVM projectVM)
        {
            return await _projectRepository.SearchAsync(projectVM);
        }



        public async Task UpdateProject(ProjectDto project)
        {
            await _projectRepository.UpdateAsync(project);
            StatusClass = "alert-success";
            Message = "Project updated successfully.";
            Saved = true;
        }

        public async Task<IEnumerable<SelectListItem>> ProjectListByCurrentUserAsync(string userName=null)
        {
          return await _projectRepository.ProjectListByCurrentUserAsync(userName);
        }
    }
}
