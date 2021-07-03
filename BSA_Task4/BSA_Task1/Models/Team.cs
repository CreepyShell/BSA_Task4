using System;
using System.Collections.ObjectModel;

namespace BSA_Task1.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public Collection<User> Users { get; set; }
        public Collection<Project> Projects { get; set; }
    }
}
