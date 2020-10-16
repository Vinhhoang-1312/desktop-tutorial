using FPT_Training_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPT_Training_System.ViewModels
{
    public class EnrollmentViewModel
    {
        public Enrollment Enrollment { get; set; }
        public IEnumerable<Trainee> Trainee { get; set; }
        public IEnumerable<CourseCategory> CourseCategories { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}