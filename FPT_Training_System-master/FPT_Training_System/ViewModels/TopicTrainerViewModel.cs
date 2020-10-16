using FPT_Training_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPT_Training_System.ViewModels
{
    public class TopicTrainerViewModel
    {
        public Trainer Trainer { get; set; }
        public IEnumerable<Topic> topics { get; set; }
    }
}