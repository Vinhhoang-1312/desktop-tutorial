using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPT_Training_System.Models
{
    public class Trainer
    {
        //public virtual ApplicationUser ApplicationUser { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string WorkingPlace { get; set;  }
        public string PhoneNumber { get; set; }
        public Topic topId { get; set; }
        public Topic Topic { get; set; }

    }
}