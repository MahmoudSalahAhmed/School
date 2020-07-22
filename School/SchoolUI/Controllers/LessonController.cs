using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace SchoolUI.Controllers
{
    public class LessonController : Controller
    {


        private readonly LessonService LessonService;

        public LessonController(LessonService _LessonService)
        {
            LessonService = _LessonService;

        }
        // GET: Home
        public ActionResult Lesson()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var Lessons = LessonService.GetAll().ToList();
            return View(Lessons);
        }

        public ActionResult Details(int id)
        {

            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            LessonViewModel Lesson = LessonService.GetByID(id);
            return View(Lesson);
        }

        public ActionResult Add()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);

            return View();
        }
        [HttpPost]
        public ActionResult Add(LessonEditViewModel Lesson)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }

            LessonService.Add(Lesson);
            return RedirectToAction("Lesson");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            LessonService.Remove(id);
            return RedirectToAction("Lesson");
        }
        public ActionResult Update(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var Lesson = LessonService.GetByID(id);

            return View(Lesson);
        }
        [HttpPost]
        public ActionResult Update(LessonEditViewModel Lesson)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }

            LessonService.Update(Lesson);
            return RedirectToAction("Lesson");
        }
    }
}