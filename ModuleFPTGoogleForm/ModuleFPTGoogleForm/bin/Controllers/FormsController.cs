using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcGoogleForm.Models;
using System.IO;
using Newtonsoft.Json;

namespace ModuleFPTGoogleForm.Controllers
{
    public class FormsController : Controller
    {
        private GoogleFormDbContext db = new GoogleFormDbContext();

        // GET: Forms
        public ActionResult Index()
        {
            return View(db.Form.ToList());
        }

       

        // GET: Forms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Form form)
        {
            if (ModelState.IsValid)
            {
                db.Form.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(form);
        }

       

       

        // GET: Forms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Form form = db.Form.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Form form = db.Form.Find(id);
            db.Form.Remove(form);
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
       
        public ActionResult DetailsQuestion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = question.QuestionId;
            ViewBag.Type = question.Type;
            ViewBag.FormId = new SelectList(db.Form, "Id", "Id", question.FormId);
            return View(question);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = question.QuestionId;
           
            ViewBag.Type = question.Type;
            ViewBag.FormId = new SelectList(db.Form, "Id", "Id", question.FormId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionId,QuestionName,Answer,Type,FormId")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormId = new SelectList(db.Form, "Id", "Id", question.FormId);
            return View(question);
        }
      
        public ActionResult DeleteQuestions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        [HttpPost, ActionName("DeleteQuestions")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed1(int id)
        {
            Question question = db.Question.Find(id);
            var idForm = question.FormId;
            db.Question.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Questions",new { id = idForm });
        }
        // GET: Questions/Create
        public ActionResult CreateQuestions()
        {
            ViewBag.FormId = new SelectList(db.Form, "Id", "Id");
           // ViewBag.IdF = id;
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuestions([Bind(Include = "QuestionId,QuestionName,Answer,Type,FormId")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Question.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormId = new SelectList(db.Form, "Id", "Id", question.FormId);
            return View(question);
        }
       
        

        
    }
}
