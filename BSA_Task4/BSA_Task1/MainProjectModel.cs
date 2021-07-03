using BSA_Task1.Models;
using System.Collections.ObjectModel;

namespace BSA_Task1
{
    public class MainProjectModel
    {
        public Project Project { get; set; }
        public User Author { get; set; }
        public Team Team { get; set; }
        public Collection<TaskM> Task { get; set; }
    }

    public class TaskM
    {
        public User Performer { get; set; }
    }
}
