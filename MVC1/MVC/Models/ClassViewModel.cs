using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ClassViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Course_ID { get; set; }
        [Required]
        public string Course_Name { get; set; }
        [Required]
        public string Instructor_Name { get; set; }
        [Required]
        public string Class_Type { get; set; }
        [Required]
        public string Class_Description { get; set; }
    } // class end
} // namespace end