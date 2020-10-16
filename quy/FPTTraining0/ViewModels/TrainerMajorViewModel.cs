using FPTTraining0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTTraining0.ViewModels
{
    public class TrainerMajorViewModel
    {
        public Trainer Trainer { get; set; }
        public IEnumerable<Major> Majors { get; set; }
    }
}