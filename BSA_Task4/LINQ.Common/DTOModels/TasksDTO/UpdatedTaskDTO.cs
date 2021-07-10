
namespace LINQ.Common.DTOModels.TasksDTO
{
    public class UpdatedTaskDTO
    {
        public string NewDescription { get; set; }
        public int? NewState { get; set; }
        public int? NewPerformerId { get; set; }
    }
}
