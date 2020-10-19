using mvc2.Models;
using System.Collections.Generic;

namespace mvc2.ViewModels
{
    public class CourseCategoryViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}