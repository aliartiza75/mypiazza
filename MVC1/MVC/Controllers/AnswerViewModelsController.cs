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
    public class AnswerViewModelsController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: AnswerViewModels
        public ActionResult Index(string id)
        {
            return View(from a in db.AnswerViewModels
                        where a.Question_id == id
                        select a);
        }

        // GET: AnswerViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerViewModel answerViewModel = db.AnswerViewModels.Find(id);
            if (answerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(answerViewModel);
        }

        // GET: AnswerViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnswerViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Answer,Answer_Tag,Question_id,Sender_Email,Anonimity,IssueDate")] AnswerViewModel answerViewModel)
        {
            if (ModelState.IsValid)
            {
                db.AnswerViewModels.Add(answerViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(answerViewModel);
        }

        // GET: AnswerViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerViewModel answerViewModel = db.AnswerViewModels.Find(id);
            if (answerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(answerViewModel);
        }

        // POST: AnswerViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Answer,Answer_Tag,Question_id,Sender_Email,Anonimity,IssueDate")] AnswerViewModel answerViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answerViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(answerViewModel);
        }

        // GET: AnswerViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerViewModel answerViewModel = db.AnswerViewModels.Find(id);
            if (answerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(answerViewModel);
        }

        // POST: AnswerViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnswerViewModel answerViewModel = db.AnswerViewModels.Find(id);
            db.AnswerViewModels.Remove(answerViewModel);
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
