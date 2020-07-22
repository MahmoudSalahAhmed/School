using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace SchoolUI.Controllers
{
    public class ScheduleLessonController : Controller
    {


        private readonly ScheduleLessonService ScheduleLessonService;
        private readonly TeacherService TeacherService;
        private readonly SubjectService SubjectService;
        private readonly LessonService LessonService;
        private readonly ScheduleService ScheduleService;

        public ScheduleLessonController(
            ScheduleLessonService _ScheduleLessonService,
            TeacherService _TeacherService,
            SubjectService _SubjectService,
            LessonService _LessonService,
            ScheduleService _ScheduleService
            )
        {
            ScheduleLessonService = _ScheduleLessonService;
            TeacherService = _TeacherService;
            SubjectService = _SubjectService;
            LessonService = _LessonService;
            ScheduleService = _ScheduleService;


        }
        // GET: Home
        public ActionResult ScheduleLesson()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var ScheduleLessons = ScheduleLessonService.GetAll().ToList();
            return View(ScheduleLessons);
        }

        public ActionResult Details(int id)
        {

            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            ScheduleLessonViewModel ScheduleLesson = ScheduleLessonService.GetByID(id);
            return View(ScheduleLesson);
        }

        public ActionResult Add(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            ViewBag.Teachers = TeacherService.GetAll().Select(i=>i.User);
            ViewBag.Lessons = LessonService.GetAll();
            ViewBag.Subjects = SubjectService.GetAll();
            Session["Schedule"] = id;
            var Schedule = ScheduleService.GetByID(id);
            ViewBag.Schedule = Schedule;
            ViewBag.ClassRoomID = Schedule.ClassRoomID;
            return View();
        }
        [HttpPost]
        public ActionResult Add(ScheduleLessonEditViewModel ScheduleLesson)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }

            ScheduleLesson.ScheduleID = (int)Session["Schedule"];
            ScheduleLessonService.Add(ScheduleLesson);
            return RedirectToAction("Add", new { id = (int)Session["Schedule"]});
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ScheduleLessonService.Remove(id);
            return RedirectToAction("Add", new { id = (int)Session["Schedule"] });
        }
        public ActionResult Update(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var ScheduleLesson = ScheduleLessonService.GetByID(id);

            ViewBag.Teachers = TeacherService.GetAll().Select(i => i.User);
            ViewBag.Lessons = LessonService.GetAll();
            ViewBag.Subjects = SubjectService.GetAll();
            ViewBag.Schedule = ScheduleLesson.Schedule;
            Session["Schedule"] = ScheduleLesson.ScheduleID;

            return View(ScheduleLesson);
        }
        [HttpPost]
        public ActionResult Update(ScheduleLessonEditViewModel ScheduleLesson)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            ScheduleLesson.ScheduleID = (int)Session["Schedule"];
            ScheduleLessonService.Update(ScheduleLesson);
            return RedirectToAction("Add", new { id = (int)Session["Schedule"] });
        }
    }
}