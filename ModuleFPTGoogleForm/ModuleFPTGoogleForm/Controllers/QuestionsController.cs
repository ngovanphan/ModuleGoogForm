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
using ModuleFPTGoogleForm.Models;
using System.Data.Common;
using System.Dynamic;
using System.ComponentModel;

namespace ModuleFPTGoogleForm.Controllers
{
    public class QuestionsController : Controller
    {
        private GoogleFormDbContext db = new GoogleFormDbContext();

        public ActionResult AddType()
        {
            return PartialView("_AddType");
        }
        public ActionResult AddCheckBox()
        {
            return PartialView("_AddCheckBox");
        }
        // GET: Questions
        public ActionResult Index(int? id)
        {
            int pageCount = db.Question.Where(x => x.FormId == id).ToList().Count() / 10 + 1;
            ViewBag.PageNumber = 1;
            ViewBag.PageCount = pageCount;
            ViewBag.IdForm = id;
            return View();
        }
        //lấy tất cả question theo formID
        public ActionResult GetALLQuestions(int? id)
        {
            List<Question> question = db.Question.Where(x => x.FormId == id).ToList();
            


            return Json(question, JsonRequestBehavior.AllowGet);
        }
        // GET: Questions/Details/5
        public ActionResult Details(int? id)
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
            ViewBag.Anwser = question.Answer;
            ViewBag.Type = question.Type;
            ViewBag.FormId = new SelectList(db.Form, "Id", "Id", question.FormId);
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.FormId = new SelectList(db.Form, "Id", "Id");
            return View();
        }
        
        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionId,QuestionName,Answer,Type,FormId")] Question question)
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
     
        public ActionResult createQuestions(Question question)
        {
            db.Question.Add(question);
            db.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public void AddNewQuestions()
        {
            var resolveRequest = HttpContext.Request;
            resolveRequest.InputStream.Seek(0, SeekOrigin.Begin);
            string jsonString = new StreamReader(resolveRequest.InputStream).ReadToEnd();
            var obj = System.Web.Helpers.Json.Decode(jsonString);

            Question question = new Question();
            question.QuestionName = obj.QuestionName;
            question.Answer = obj.Answer;
            question.Type = obj.Type;
            question.FormId = obj.FormId;
           
            if (!TryValidateModel(question))
            {
                TempData["errorBug"] = "The information you entered is incorrect, please try again!";
            }
            else
            {
                TempData["errorBug"] = "";
                db.Question.Add(question);
                db.SaveChanges();
            }
        }
        public void EditQuestions()
        {
            var resolveRequest = HttpContext.Request;
            resolveRequest.InputStream.Seek(0, SeekOrigin.Begin);
            string jsonString = new StreamReader(resolveRequest.InputStream).ReadToEnd();
            var obj = System.Web.Helpers.Json.Decode(jsonString);

            Question question = new Question();
            question.QuestionId = (int)obj.QuestionId;
            question.QuestionName = obj.QuestionName;
            question.Answer = obj.Answer;
            question.Type = obj.Type;
            question.FormId = obj.FormId;
           
            db.Entry(question).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        // get questions by id
        public JsonResult getQuestionsById(string id)
        {
            return Json(db.Question.Find(id), JsonRequestBehavior.AllowGet);
        }
        // GET: Questions/Edit/5
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
            ViewBag.Anwser = question.Answer;
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

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Question.Find(id);
            var formId = question.FormId;
            db.Question.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index/"+formId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
      
        // duplicate questions
        public ActionResult Duplicate(int? id)
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
            ViewBag.Anwser = question.Answer;
            ViewBag.Type = question.Type;
            ViewBag.FormId = new SelectList(db.Form, "Id", "Id", question.FormId);
            return View(question);
        }
        // View Question theo dạng user
        public ActionResult EditUser(int? id)
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
            ViewBag.Anwser = question.Answer;
            ViewBag.Type = question.Type;
            ViewBag.FormId = new SelectList(db.Form, "Id", "Id", question.FormId);
            return View(question);
        }
        public ActionResult ViewEndUser(int? id)
        {
          
            ViewBag.IdForm = id;
            return View();
        }
        public ActionResult GetQuestionsByForm(int? id)
        {
            List<Question> question = db.Question.Where(x => x.FormId == id).ToList();
            //var list = question.Skip((Int32.Parse(page) - 1) * 10).Take(10).ToList();
            return Json(question, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetQuestionsByUserId(string id)
        {
            List<Question> question = db.Question.ToList();
           
            return Json(question, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult DetailFormByUserId(int id,int userId)
        {
            ViewBag.IdForm = id;
            ViewBag.UserId = userId;
            return View();
        }
        public List<Dictionary<string, object>> Read(DbDataReader reader)
        {
            List<Dictionary<string, object>> expandolist = new List<Dictionary<string, object>>();
            foreach (var item in reader)
            {
                IDictionary<string, object> expando = new ExpandoObject();
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(item))
                {
                    var obj = propertyDescriptor.GetValue(item);
                    expando.Add(propertyDescriptor.Name, obj);
                }
                expandolist.Add(new Dictionary<string, object>(expando));
            }
            return expandolist;
        }
        public ActionResult ViewAdmin(int id)
        {
            ViewBag.IdForm = id;
            using (var ctx = new GoogleFormDbContext())
            using (var cmd = ctx.Database.Connection.CreateCommand())
            {
                ctx.Database.Connection.Open();
                cmd.CommandText = "EXEC [dbo].[DynamicPivot] " + id;
                using (var reader = cmd.ExecuteReader())
                {
                    var model = this.Read(reader).ToList();
                    return View(model);
                }
            }
        }
    }
}
