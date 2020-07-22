using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace SchoolUI.Controllers
{
    public class SubjectController : Controller
    {


        private readonly SubjectService SubjectService;
        
        public SubjectController(SubjectService _SubjectService)
        {
            SubjectService = _SubjectService;
            
        }
        // GET: Home
        public ActionResult Subject()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var Subjects = SubjectService.GetAll().ToList();
            return View(Subjects);
        }

        public ActionResult Details(int id)
        {

            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            SubjectViewModel Subject = SubjectService.GetByID(id);
            return View(Subject);
        }

        public ActionResult Add()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(SubjectEditViewModel Subject)
        {
            if (!ModelState.IsValid)
            {
               
                return View();
            }

            SubjectService.Add(Subject);
            return RedirectToAction("Subject");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            SubjectService.Remove(id);
            return RedirectToAction("Subject");
        }
        public ActionResult Update(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var Subject = SubjectService.GetByID(id);
           
            return View(Subject);
        }
        [HttpPost]
        public ActionResult Update(SubjectEditViewModel Subject)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }

            SubjectService.Update(Subject);
            return RedirectToAction("Subject");
        }
    }
}