
using System.ComponentModel.DataAnnotations;

namespace LINQ.DataAccess.Models
{
    public abstract class BaseModel
    {
        [Required]
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
    }
}
