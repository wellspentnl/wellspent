using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectService.DTOs;
using ProjectService.Entities;

namespace ProjectService.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Project, ProjectDto>().ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
            CreateMap<Entities.Task, TaskDto>();
            CreateMap<CreateProjectDto, Project>();
        }
    }
}