using System;
using System.Collections.ObjectModel;

namespace BSA_Task1.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public Collection<Task> Tasks { get; set; }
    }
}
