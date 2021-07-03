
using System;
using System.Collections.ObjectModel;

namespace LINQ.DataAccess.Models
{
    public class Team : BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public Collection<User> Users { get; set; }
        public Collection<Project> Projects { get; set; }
    }
}
