using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class TeacherViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(15)]
        [RegularExpression("^[1-4]{1}[0-9]{4}(-)?[0-9]{7}(-)?[0-9]{1}$", ErrorMessage = "CNIC is not valid")]
        public string CNIC { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Pass { get; set; }
        public string Address { get; set; }

        [RegularExpression("^([0-9]{4}(-)?[0-9]{7})$", ErrorMessage = "Contact # is not valid")]
        public string Contact { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }


    } // class end
} // namespace end