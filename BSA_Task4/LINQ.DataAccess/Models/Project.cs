
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LINQ.DataAccess.Models
{
    public class Project : BaseModel
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public User User { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public Collection<Task> Tasks { get; set; }
    }
}
