using Application.App.Services.Projects;
using Domain.App.Entities;
using AutoMapper;
using Application.App.Services.Buildings;

namespace Application.App.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Building, BuildingDto>().ReverseMap();
        }
        
    }
}
