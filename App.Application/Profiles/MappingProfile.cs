using Application.App.Services.Projects;
using Domain.App.Entities;
using AutoMapper;

namespace Application.App.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
        
    }
}
