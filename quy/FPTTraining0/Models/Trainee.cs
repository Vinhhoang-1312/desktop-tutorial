﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPTTraining0.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Trainee Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Trainee Email")]
        public string TraineeEmail { get; set; }
        [Required]
        [DisplayName("Password Email")]
        public string PassEmail { get; set; }
        [Required]
        [DisplayName("Year of Birth")]
        public string Birth { get; set; }
        [Required]
        public int CourseId  { get; set; }
        public Course Course { get; set; }
    }
}