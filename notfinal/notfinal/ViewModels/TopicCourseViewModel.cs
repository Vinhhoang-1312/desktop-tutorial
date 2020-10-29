using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using notfinal.Models;

namespace notfinal.ViewModels
{
    public class TopicCourseViewModel
    {
        public Topic Topic { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}