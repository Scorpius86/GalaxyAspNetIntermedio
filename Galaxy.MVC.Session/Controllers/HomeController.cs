using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Galaxy.MVC.Session.Models;
using Galaxy.MVC.Session.Extensions;
using Galaxy.MVC.Session.Utility;

namespace Galaxy.MVC.Session.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationData _applicationData;
        public HomeController(ApplicationData applicationData)
        {
            _applicationData = applicationData;
        }
        public IActionResult Index()
        {
            if (ViewData.Keys.Contains("Count"))
            {
                ViewData["Count"] = Convert.ToInt32(ViewData["Count"]) + 1;
            }
            else
            {
                ViewData["Count"] = 1;
            }

            if (ViewBag.Count != null)
            {
                ViewBag.Count = ViewBag.Count ++;
            }
            else
            {
                ViewBag.Count = 1;
            }

            if (TempData.Keys.Contains("Count"))
            {
                TempData["Count"] = Convert.ToInt32(TempData["Count"]) + 1;
            }
            else
            {
                TempData["Count"] = 1;
            }

            if (HttpContext.Session.Keys.Contains("Count"))
            {
                HttpContext.Session.Set<int>("Count", HttpContext.Session.Get<int>("Count") + 1);
            }
            else
            {
                HttpContext.Session.Set<int>("Count", 1);
            }

            if (_applicationData.Keys.Contains("Count"))
            {
                _applicationData.Set<int>("Count", _applicationData.Get<int>("Count") + 1);
            }
            else
            {
                _applicationData.Set<int>("Count", 1);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
