using AutoMapper;
using LINQ.DataAccess.Models;
using LINQ.Common.DTOModels;

namespace LINQ.BL.MappingSettings
{
    public sealed class MapUser:Profile
    {
        public MapUser()
        {
            CreateMap<User, UserDTO>()
                .ForMember(user => user.FirstName, scr => scr.MapFrom(s => s.Name))
                .ForMember(user => user.LastName, scr => scr.MapFrom(s => s.Name));               
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Name, scr => scr.MapFrom(s => s.FirstName + "  " + s.LastName));
        }
    }
}
