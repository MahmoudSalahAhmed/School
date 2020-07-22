using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace SchoolUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdminService adminService;
        private readonly StatisticsService StatisticsService;
        public HomeController(AdminService _adminService , StatisticsService _StatisticsService)
        {
            adminService = _adminService;
            StatisticsService = _StatisticsService;
        }
        public ActionResult Index()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Home", null);

            var Statistics = StatisticsService.GetStatistics();
            return View(Statistics);
        }

        [HttpGet]        public ActionResult Login()        {            return View();        }        [HttpPost]        public ActionResult Login(AdminEditViewModel admin)        {            AdminViewModel user = adminService.GetAll().                FirstOrDefault(i => i.User.Email == admin.User.Email                && i.Password == admin.Password);            if (string.IsNullOrEmpty(admin.Password)||string.IsNullOrEmpty(admin.User.Email))            {                if (admin.User.Email == null || admin.User.Email == "")                    ViewBag.Email = "Email is required";                if (admin.Password == null || admin.Password == "")                    ViewBag.Password = "Password is required";                return View();            }


            if (user == null)            {                ViewBag.ValidAdmin = "This Account Is InValid";                return View();            }            else            {                Session["User"] = user;                return RedirectToAction("Index", "Home", null);
                
            }

        }
        [HttpGet]
        public ActionResult LogOut()
        {

            Session["User"] = null;

            return RedirectToAction("Login", "Home", null);


        }
    }
}