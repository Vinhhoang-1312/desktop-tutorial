﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using notfinal.Models;

namespace notfinal.ViewModels
{
    public class CourseCategoryViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}