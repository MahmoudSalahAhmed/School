using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace SchoolUI.Controllers
{
    public class TeacherController : Controller
    {


        private readonly TeacherService TeacherService;
        
        public TeacherController(TeacherService _TeacherService)
        {
            TeacherService = _TeacherService;
            
        }
        // GET: Home
        public ActionResult Teacher()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var Teachers = TeacherService.GetAll().ToList();
            return View(Teachers);
        }

        public ActionResult Details(int id)
        {

            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            TeacherViewModel Teacher = TeacherService.GetByID(id);
            return View(Teacher);
        }

        public ActionResult Add()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(TeacherEditViewModel Teacher)
        {
            if (!ModelState.IsValid)
            {
               
                return View();
            }

            TeacherService.Add(Teacher);
            return RedirectToAction("Teacher");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            TeacherService.Remove(id);
            return RedirectToAction("Teacher");
        }
        public ActionResult Update(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var Teacher = TeacherService.GetByID(id);
           
            return View(Teacher);
        }
        [HttpPost]
        public ActionResult Update(TeacherEditViewModel Teacher)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            Teacher.User.ID = Teacher.ID;
            TeacherService.Update(Teacher);
            return RedirectToAction("Teacher");
        }
    }
}