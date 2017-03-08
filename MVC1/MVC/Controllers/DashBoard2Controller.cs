using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC.Models;

namespace MVC.Controllers
{
    public class DashBoard2Controller : Controller
    {
        private UserDBContext db = new UserDBContext();
        // GET: DashBoard2
        public ActionResult Index()
        {
            return View();
        } // func end

        public ActionResult Add_Class ()
        {

            return View();
        } // func end
        public int Add_class_db( string class_id, string class_name, string instruct_name, string class_type, string class_description)
        {
            try
            {
                bool contactExists = db.list_of_course.Any(ClassViewModel => ClassViewModel.Course_ID.Equals(class_id));
                if (contactExists)
                {
                    return 3;
                }
                else { 
                    var obj = new ClassViewModel();
                    obj.Course_ID = class_id;
                    obj.Course_Name = class_name;
                    obj.Instructor_Name = instruct_name;
                    obj.Class_Type = class_type;
                    obj.Class_Description = class_description;

                    db.list_of_course.Add(obj);
                    db.SaveChanges();
                    return 0;
                } // else end


            } // try end
            catch (Exception ee)
            {
                Console.WriteLine(ee);
                return 2;
            } // cathc end
        } // func end

        public ActionResult Profilee()
        {
            int s = int.Parse(Session["id"].ToString());
            return View( db.list_of_teacher.Find(s) );

        }// funtion end

    }// class end
} // namespace end