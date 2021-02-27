using Application.App.Contracts.Persistence;
using Domain.App.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectDto> _logger;


        public ProjectService(IMapper mapper, IProjectRepository projectRepository, ILogger<ProjectDto> logger)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _logger = logger;
        }


        public async Task<Guid> AddProject(ProjectDto project)
        {
            var validator = new ProjectValidator(_projectRepository);
            var validationResult = await validator.ValidateAsync(project);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            var prject = _mapper.Map<Project>(project);
            prject = await _projectRepository.AddAsync(prject);
            return prject.Id;
        }

        public async Task DeleteProjectAsync(Project project)
        {
            throw new NotImplementedException();
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

        public async Task UpdateProject(Project project)
        {
            await _projectRepository.UpdateAsync(project);
        }
    }
}
