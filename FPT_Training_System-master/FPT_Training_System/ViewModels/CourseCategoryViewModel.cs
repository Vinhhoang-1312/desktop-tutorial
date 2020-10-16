using FPT_Training_System.Models;
using System.Collections.Generic;

namespace FPT_Training_System.ViewModels
{
    public class CourseCategoryViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}