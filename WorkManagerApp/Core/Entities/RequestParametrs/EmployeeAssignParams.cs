using System.ComponentModel.DataAnnotations;

namespace Core.Entities.RequestParametrs
{
    public class EmployeeAssignParams
    {
        [Required]
        public DateTime StartAt { get; set; }
        [Required]
        public Guid Id { get; set; }
    }
}
