using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC.Models
{
    public class UserDBContext : DbContext
    {
        public DbSet<Users> list_of_user { get; set; }
        public DbSet<TeacherViewModel> list_of_teacher { get; set; }
        public DbSet<ClassViewModel> list_of_course { get; set; }
        public DbSet<QuestionViewModel> list_of_question { get; set; }

        public DbSet<Course_Registration> course_registration { get; set; }

        public System.Data.Entity.DbSet<MVC.Models.AnswerViewModel> AnswerViewModels { get; set; }
    } // class end
}// namespace end