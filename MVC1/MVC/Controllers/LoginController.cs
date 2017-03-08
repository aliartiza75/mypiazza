using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        private UserDBContext db = new UserDBContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public int insert_user(string name,string pass)
        {
            var obj = new Users();
            obj.Name = name;
            obj.Pass = pass;
            db.list_of_user.Add(obj);
            db.SaveChanges();
            return 1;
        }

        public int validate_user ( string email, string pass ,  int choice )
        {
            // var obj = db.list_of_user.Find(Convert.ToInt16(name));
            //return Redirect("~/Login/Index");

            if ( choice  == 1)
            {
                bool contactExists = db.list_of_user.Any(Users => Users.Email.Equals(email));

                if (contactExists)
                {
                    var query = from a in db.list_of_user
                                where a.Email == (email)
                                select new
                                {
                                    Namee = a.Name,
                                    Contact = a.Contact,
                                    Id = a.Email,
                                    p = a.ID,

                                };
                    foreach (var s in query)
                    {
                        Session["Name"] = s.Namee;
                        Session["Contact"] = s.Contact;
                        Session["Email"] = s.Id;
                        Session["id"] = s.p;
                        break;
                    }
                    return 1;
                    
                } // if end
                else
                {
                    return 0;
                }
            }// if end
            else if ( choice == 2) // teacher check
            {
                bool contactExists = db.list_of_teacher.Any(TeacherViewModel => TeacherViewModel.Email.Equals(email));
                if (contactExists)
                {
                    var query = from a in db.list_of_teacher
                                where a.Email == (email)
                                select new
                                {
                                    Namee = a.Name,
                                    Contact = a.Contact,
                                    Id = a.Email,
                                    p = a.ID,

                                };
                    foreach (var s in query)
                    {
                        Session["Name"] = s.Namee;
                        Session["Contact"] = s.Contact;
                        Session["Email"] = s.Id;
                        Session["id"] = s.p;
                        break;
                    }
                    return 2;
                }
                else
                {
                    return 0;
                }
            }// else end
            return 6;
        } // function end


    }
}