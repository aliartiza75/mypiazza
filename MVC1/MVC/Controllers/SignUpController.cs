using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC.Models;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace MVC.Controllers
{
    public class SignUpController : Controller
    {
        private UserDBContext db = new UserDBContext();
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }


        public bool Email (string _name, String _emailTo, String _password)
        {
            try {

                string smtpAddress = "smtp.mail.yahoo.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "aliartiza75@yahoo.com";
                string password = "321sas123";
                string emailTo = _emailTo;
                string subject = "Hello "+_name;
                string body = "Mr/Mrs "+_name+" we welcome you to our website";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
               
                SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
                return false;
            }
        }


        public int sign_up (string cnicc, string name, string password, string address, string contact , string emaill, int choice)
        {
            try {
                if (choice == 1)
                {
                    bool contactExists = db.list_of_user.Any(Users => Users.Email.Equals(emaill));
                    if ( contactExists)
                    {
                        return 3;
                    }
                    var obj = new Users();
                    obj.CNIC = cnicc;
                    obj.Name = name;
                    obj.Pass = password;
                    obj.Address = address;
                    obj.Contact = contact;
                    obj.Email = emaill;

                    if ( Email(name, emaill, password) == true)
                    {
                        db.list_of_user.Add(obj);
                        db.SaveChanges();
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                    
                }
                else if (choice == 2) // Teacher
                {
                    bool contactExists = db.list_of_teacher.Any(TeacherViewModel => TeacherViewModel.Email.Equals(emaill));
                    if (contactExists)
                    {
                        return 3;
                    }
                    var obj2 = new TeacherViewModel();
                    obj2.CNIC = cnicc;
                    obj2.Name = name;
                    obj2.Pass = password;
                    obj2.Address = address;
                    obj2.Contact = contact;
                    obj2.Email = emaill;

                    if (Email(name, emaill, password) == true)
                    {
                        db.list_of_teacher.Add(obj2);
                        db.SaveChanges();
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }      
                 } // else end


                return 1;
            }
            catch ( Exception ee)
            {
                Console.WriteLine(  ee);
                return 2;
            } // cathc end
           
        }// function end
    } // class end
} // namespace send