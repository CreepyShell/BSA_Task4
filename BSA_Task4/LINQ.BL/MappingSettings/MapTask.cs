using AutoMapper;
using LINQ.Common.DTOModels;
using LINQ.DataAccess.Models;

namespace LINQ.BL.MappingSettings
{
    public sealed class MapTask:Profile
    {
        public MapTask()
        {
            CreateMap<Task, TaskDTO>();
            CreateMap<TaskDTO, Task>();
        }
    }
}
