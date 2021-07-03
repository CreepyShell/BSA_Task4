using System;
using System.Collections.ObjectModel;

namespace LINQ.DataAccess.Models
{
    public class User : BaseModel
    {
        public int? TeamId { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime? BirthDay { get; set; }
        public Collection<Task> Tasks { get; set; }
        public Collection<Project> Projects { get; set; }
    }
}
