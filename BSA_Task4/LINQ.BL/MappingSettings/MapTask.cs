using AutoMapper;
using LINQ.Common.DTOModels;
using System.Threading.Tasks;

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
