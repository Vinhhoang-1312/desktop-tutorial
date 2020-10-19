using mvc2.ViewModels;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace mvc2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Course Name")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }



    }
}