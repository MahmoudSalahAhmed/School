﻿using Services;
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

        [HttpGet]


            if (user == null)
                
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