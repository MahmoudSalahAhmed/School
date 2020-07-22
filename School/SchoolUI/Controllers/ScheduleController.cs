using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace SchoolUI.Controllers
{
    public class ScheduleController : Controller
    {


        private readonly ScheduleService ScheduleService;
        private readonly ClassRoomService ClassRoomService;
        private readonly DayService DayService;

        public ScheduleController(
            ScheduleService _ScheduleService,
            ClassRoomService _ClassRoomService,
            DayService _DayService
            )
        {
            ScheduleService = _ScheduleService;
            ClassRoomService = _ClassRoomService;
            DayService = _DayService;
        }
        // GET: Home
        public ActionResult Schedule()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var Schedules = ScheduleService.GetAll().ToList();
            return View(Schedules);
        }

        public ActionResult Details(int id)
        {

            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            ScheduleViewModel Schedule = ScheduleService.GetByID(id);
            return View(Schedule);
        }

        public ActionResult Add(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            ViewBag.Classes = ClassRoomService.GetAll();
            ViewBag.Days = DayService.GetAll();
            ViewBag.ClassR = ClassRoomService.GetByID(id);
            Session["ClassRoomID"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult Add(ScheduleEditViewModel Schedule)
        {
            if (!ModelState.IsValid)
            {
               
                return View();
            }
            ViewBag.Classes = ClassRoomService.GetAll();
            ViewBag.Days = DayService.GetAll();
            ViewBag.ClassR = ClassRoomService.GetByID(Schedule.ClassRoomID);
            ScheduleService.Add(Schedule);
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ScheduleService.Remove(id);
            return RedirectToAction("Add", new { id = (int)Session["Schedule"] });
        }
        public ActionResult Update(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var Schedule = ScheduleService.GetByID(id);
            ViewBag.Classes = ClassRoomService.GetAll();
            ViewBag.Days = DayService.GetAll();
            ViewBag.ClassR = ClassRoomService.GetByID(Schedule.ClassRoomID);
            Session["ClassRoomID"] = Schedule.ClassRoomID;
            return View(Schedule);
        }
        [HttpPost]
        public ActionResult Update(ScheduleEditViewModel Schedule)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }

            ScheduleService.Update(Schedule);
            return RedirectToAction("Add", new {id =  Schedule.ClassRoomID });
        }
    }
}