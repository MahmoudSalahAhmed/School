using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace SchoolUI.Controllers
{
    public class ClassRoomController : Controller
    {


        private readonly ClassRoomService ClassRoomService;
        private readonly LessonService LessonService;

        public ClassRoomController(ClassRoomService classRoomService, LessonService _LessonService)
        {
            ClassRoomService = classRoomService;
            LessonService = _LessonService;
        }
        // GET: Home
        public ActionResult ClassRoom()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var ClassRooms = ClassRoomService.GetAll().ToList();
            return View(ClassRooms);
        }

        public ActionResult Details(int id)
        {

            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            ViewBag.Lessons = LessonService.GetAll();
            ClassRoomViewModel ClassRoom = ClassRoomService.GetByID(id);
            return View(ClassRoom);
        }

        public ActionResult Add()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(ClassRoomEditViewModel ClassRoom)
        {
            if (!ModelState.IsValid)
            {
               
                return View();
            }
            ClassRoomService.Add(ClassRoom);
            return RedirectToAction("ClassRoom");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ClassRoomService.Remove(id);
            return RedirectToAction("ClassRoom");
        }
        public ActionResult Update(int id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);
            var ClassRoom = ClassRoomService.GetByID(id);
           
            return View(ClassRoom);
        }
        [HttpPost]
        public ActionResult Update(ClassRoomEditViewModel ClassRoom)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }

            ClassRoomService.Update(ClassRoom);
            return RedirectToAction("ClassRoom");
        }
    }
}