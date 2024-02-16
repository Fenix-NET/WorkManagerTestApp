﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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