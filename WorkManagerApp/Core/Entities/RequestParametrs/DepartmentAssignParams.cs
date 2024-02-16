using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
