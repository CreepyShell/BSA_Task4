using AutoMapper;
using LINQ.Common.DTOModels;
using LINQ.DataAccess.Models;

namespace LINQ.BL.MappingSettings
{
    public sealed class MapTeam : Profile
    {
        public MapTeam()
        {
            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();
        }
    }
}
