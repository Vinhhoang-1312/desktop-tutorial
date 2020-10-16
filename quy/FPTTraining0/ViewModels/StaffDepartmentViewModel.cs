using FPTTraining0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTTraining0.ViewModels
{
    public class StaffDepartmentViewModel
    {
        public Staff Staff { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}