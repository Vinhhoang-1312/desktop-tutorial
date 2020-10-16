using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPTTraining0.Models
{
    public class Major
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Major Name")]
        public string Name { get; set; }
    }
}