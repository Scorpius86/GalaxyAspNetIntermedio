using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Galaxy.MVC.Helper.Models;
using Galaxy.MVC.Helper.ApplicationService;

namespace Galaxy.MVC.Helper.Controllers
{
    public class HomeController : Controller
    {
        private ICoreApplicationService _coreApplicationService;

        public HomeController(ICoreApplicationService coreApplicationService)
        {
            _coreApplicationService = coreApplicationService;
        }
        public IActionResult Index()
        {
            HelperViewModel helperViewModel = new HelperViewModel
            {
                ArticlesStringBuilder = _coreApplicationService.ListArticles(),
                ArticlesTagBuilder = _coreApplicationService.ListArticles(),
                ArticlesTagHelper = _coreApplicationService.ListArticles()
            };
            return View(helperViewModel);
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
