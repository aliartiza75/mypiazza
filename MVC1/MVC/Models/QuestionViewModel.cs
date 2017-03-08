using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class QuestionViewModel
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Enter the field.")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Enter the field.")]
        [StringLength(35)]
        public string Question_Tag { get; set; }
        [Required(ErrorMessage = "Enter the field.")]
        public string Course_id { get; set; }
        [Required(ErrorMessage = "Enter the field.")]
        public string Sender_Email { get; set; }
        [Required(ErrorMessage = "Enter the field.")]
        public string Anonimity { get; set; }

        [Required(ErrorMessage = "Enter the Issued date.")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; } 


    } // class end
} // namespace end