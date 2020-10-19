using mvc2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc2.ViewModel
{
    public class TopicCourseViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public Topic Topic { get; set; }
    }
}