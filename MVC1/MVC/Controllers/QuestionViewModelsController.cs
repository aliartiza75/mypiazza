using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class QuestionViewModelsController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: QuestionViewModels
        public ActionResult Index(String id)
        {
            Session["Course_Id"] = id;
            //return View(db.list_of_question.ToList());
            return View(from a in db.list_of_question
                        where a.Course_id == id
                        select a);
            
        }

        // GET: QuestionViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionViewModel questionViewModel = db.list_of_question.Find(id);
            if (questionViewModel == null)
            {
                return HttpNotFound();
            }
            return View(questionViewModel);
        }

        // GET: QuestionViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Question,Question_Tag,Course_id,Sender_Email,Anonimity,IssueDate")] QuestionViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                db.list_of_question.Add(questionViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionViewModel);
        }

        // GET: QuestionViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionViewModel questionViewModel = db.list_of_question.Find(id);
            if (questionViewModel == null)
            {
                return HttpNotFound();
            }
            return View(questionViewModel);
        }

        // POST: QuestionViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Question,Question_Tag,Course_id,Sender_Email,Anonimity,IssueDate")] QuestionViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionViewModel);
        }

        // GET: QuestionViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionViewModel questionViewModel = db.list_of_question.Find(id);
            if (questionViewModel == null)
            {
                return HttpNotFound();
            }
            return View(questionViewModel);
        }

        // POST: QuestionViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionViewModel questionViewModel = db.list_of_question.Find(id);
            db.list_of_question.Remove(questionViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
