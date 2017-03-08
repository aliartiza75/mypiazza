using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DashBoardController : Controller
    {
        private UserDBContext db = new UserDBContext();
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show_Course()
        {
            return View();
        }// function end

        public ActionResult Ask_Question ()
        {
            // return View();
            string ss = Session["Email"].ToString();
            var query = (from obj in db.course_registration where (obj.Student_id ==  ss ) select obj);

            var query2 = (from b in db.list_of_course
                          join a in query
                          on b.Course_ID equals a.Course_id
                          select b);
            return View(query2);
        } // func end


        public ActionResult Course_Registration()
        {
                      /*  return View(from dd in db.course_registration
                                    join a in db.list_of_course
                                    on dd.Student_id equals Session["Email"] select a);
              */
           return View(db.list_of_course.ToList());
        } // function end

        public int Db_Insert_Course (string Student_id, string Course_id)
        {
            try
            {
                var query = from a in db.course_registration where (a.Course_id == Course_id) && (a.Student_id == Student_id) select a;
                string str = null;
                foreach (var s in query)
                {
                    str = s.Course_id;
                    break;
                } // foreach end

                if (str == null)
                {
                    Course_Registration obj = new Models.Course_Registration();
                    obj.Student_id = Student_id;
                    obj.Course_id = Course_id;

                    db.course_registration.Add(obj);
                    db.SaveChanges();
                    return 1;
                } //if end
                else
                {
                    return 2;
                }// else end

            } // try end
            catch (Exception ee)
            {
                Console.WriteLine(ee);
                return 3;
            }
        } // function end
        public ActionResult Profilee ()
        {
            int s = int.Parse(Session["id"].ToString());
            return View(db.list_of_user.Find(s));

        }// funtion end

    } // class end 
} // namespace end