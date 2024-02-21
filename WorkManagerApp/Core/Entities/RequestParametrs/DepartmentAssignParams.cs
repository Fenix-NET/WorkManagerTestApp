using System.ComponentModel.DataAnnotations;

namespace Core.Entities.RequestParametrs
{
    public class DepartmentAssignParams
    {
        [Required]
        public DateTime StartAt { get; set; }
        [Required]
        public string department { get; set; }
    }
}
