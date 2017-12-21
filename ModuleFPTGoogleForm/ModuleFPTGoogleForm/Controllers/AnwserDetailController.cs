using ModuleFPTGoogleForm.Models;
using MvcGoogleForm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuleFPTGoogleForm.Controllers
{
    public class AnwserDetailController : Controller
    {
        private GoogleFormDbContext db = new GoogleFormDbContext();
        // GET: AnwserDetail
        public ActionResult Index()
        {
            return View();
        }
        public void AddAnwserDetail()
        {
            var resolveRequest = HttpContext.Request;
            resolveRequest.InputStream.Seek(0, SeekOrigin.Begin);
            string jsonString = new StreamReader(resolveRequest.InputStream).ReadToEnd();
            var obj = System.Web.Helpers.Json.Decode(jsonString);

            AnwserDetail anwserD = new AnwserDetail();
            anwserD.Detail = obj.Detail;
            anwserD.UserId = obj.UserId;
            anwserD.QuestionId = obj.QuestionId;
          

            if (!TryValidateModel(anwserD))
            {
                TempData["errorBug"] = "The information you entered is incorrect, please try again!";
            }
            else
            {
                TempData["errorBug"] = "";
                db.AnwserDetail.Add(anwserD);
                db.SaveChanges();
            }
        }
        public ActionResult GetAllAnwser()
        {
            List<AnwserDetail> anwserDetail = db.AnwserDetail.ToList();
            return Json(anwserDetail, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAnwserByQuestionId(int? id)
        {
            List<AnwserDetail> anwserD = db.AnwserDetail.Where(x => x.QuestionId == id).ToList();
            return Json(anwserD, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAnwserByUserId(int? id)
        {
            List<AnwserDetail> anwserDe = db.AnwserDetail.Where(x => x.UserId == id).ToList();
            return Json(anwserDe, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAnwserByUserIdQuestionId(int id,int? questionsId)
        {
            ViewBag.QuestionId = questionsId;
            List<AnwserDetail> anwserDe = db.AnwserDetail.Where(x => x.UserId == id && x.QuestionId == questionsId).ToList();
            return Json(anwserDe, JsonRequestBehavior.AllowGet);
        }
    }
       
    
}