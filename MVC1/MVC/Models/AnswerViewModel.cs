using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class AnswerViewModel
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Enter the field.")]
        public string Answer { get; set; }
        [Required(ErrorMessage = "Enter the field.")]
        [StringLength(35)]
        public string Answer_Tag { get; set; }
        [Required(ErrorMessage = "Enter the field.")]
        public string Question_id { get; set; }
        [Required(ErrorMessage = "Enter the field.")]
        public string Sender_Email { get; set; }
        [Required(ErrorMessage = "Enter the field.")]
        public string Anonimity { get; set; }
        [Required(ErrorMessage = "Enter the Issued date.")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

    } // class end
} // function end