using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Application.App.Services.Common;

namespace Application.App.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectDto> _logger;
        private readonly IAttachmentService _attachmentService;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;


        public ProjectService(IMapper mapper, IProjectRepository projectRepository, ILogger<ProjectDto> logger, IAttachmentService attachmentService)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _logger = logger;
            _attachmentService = attachmentService;
        }


        public async Task<Guid> AddProject(ProjectDto project)
        {
            try
            {
                var validator = new ProjectValidator(_projectRepository);
                var validationResult = await validator.ValidateAsync(project);

                if (validationResult.Errors.Count > 0)
                    throw new Exceptions.ValidationException(validationResult);
                var prject = _mapper.Map<Project>(project);
                prject.Number = GenerateProjectNumber();

                //if (selectedFiles != null)//take first image
                //{
                //    var file = selectedFiles[0];
                //    Stream stream = file.OpenReadStream();
                //    MemoryStream ms = new MemoryStream();
                //    await stream.CopyToAsync(ms);
                //    stream.Close();

                //    Model.ImageName = file.Name;
                //    Model.ImageContent = ms.ToArray();

                //    string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
                //    var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{Model.ImageName}";
                //    var fileStream = System.IO.File.Create(path);
                //    fileStream.Write(Model.ImageContent, 0, Model.ImageContent.Length);
                //    fileStream.Close();
                //    Model.ImageName = $"https://{currentUrl}/uploads/{Model.ImageName}";
                //}
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

        //public async Task<Guid> DeleteProject(ProjectDto project)
        //{
        //    var proj = _mapper.Map<Project>(project);
        //    proj = await _projectRepository.DeleteAsync(proj);
        //    return proj.Id;
        //}



        public async Task DeleteProjectAsync(Guid projectId)
        {
            await _projectRepository.DeleteAsync(projectId);
        }

        public async Task<Project> GetProjectByIdAsync(Guid Id)
        {
            var obj = await _projectRepository.GetByIdAsync(Id);
            return obj;

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


    }
}
