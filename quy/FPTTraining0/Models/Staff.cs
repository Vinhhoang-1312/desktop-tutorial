using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPTTraining0.Models
{
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Staff Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Staff Email")]
        public string StaffEmail { get; set; }
        [Required]
        [DisplayName("Password Email")]
        public string PassEmail { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}