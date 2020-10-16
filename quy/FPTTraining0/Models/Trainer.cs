using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPTTraining0.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Trainer Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Trainer Email")]
        public string TrainerEmail { get; set; }
        [Required]
        [DisplayName("Password Email")]
        public string PassEmail { get; set; }
        [Required]
        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}