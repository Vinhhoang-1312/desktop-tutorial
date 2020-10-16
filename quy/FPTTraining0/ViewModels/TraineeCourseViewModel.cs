using FPTTraining0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTTraining0.ViewModels
{
    public class TraineeCourseViewModel
    {
        public Trainee Trainee { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}