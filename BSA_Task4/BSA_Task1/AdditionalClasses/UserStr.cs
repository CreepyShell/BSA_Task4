using BSA_Task1.Models;

namespace BSA_Task1.AdditionalClasses
{
    public class UserStr
    {
        public User User { get; set; }
        public Project LastProject { get; set; }
        public int AmountOfTasks { get; set; }
        public int AmountCanceledTasks { get; set; }
        public Task LongestTask { get; set; }
    }
}
