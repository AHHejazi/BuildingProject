﻿using Application.App.Services.Projects;
using Domain.App.Entities;
using AutoMapper;
using Application.App.Services.Buildings;
using Domain.App.Entities.Lookup;
using Application.App.Services.Supplies;
using Application.App.Services.Components;

namespace Application.App.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Building, BuildingDto>().ReverseMap();
            CreateMap<SuppliesDto, Supplement>().ReverseMap();
            CreateMap<ComponentDto, Component>().ReverseMap();
        }

    }
}
