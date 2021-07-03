
using System;
using System.ComponentModel.DataAnnotations;

namespace LINQ.DataAccess.Models
{
    public  class Task : BaseModel
    {
        [Required(ErrorMessage = "No id of element")]
        public int ProjectId { get; set; }
        [Required]
        public User User { get; set; }
        public int PerformerId { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
