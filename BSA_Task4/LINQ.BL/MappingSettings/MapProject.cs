using AutoMapper;
using LINQ.Common.DTOModels;
using LINQ.DataAccess.Models;

namespace LINQ.BL.MappingSettings
{
    public sealed class MapProject : Profile
    {
        public MapProject()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
        }
    }
}
