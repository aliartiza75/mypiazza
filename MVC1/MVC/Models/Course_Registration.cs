using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Course_Registration
    {
        [Key]
        [Required]
        public int R_ID { get; set; }

        public string Course_id { get; set; }

        public string Student_id { get; set; }
       

    }// class end
} // namespace end