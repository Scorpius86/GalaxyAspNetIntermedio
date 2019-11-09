using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Galaxy.MVC.Filter.Models;
using Galaxy.MVC.Filter.Filter;
using Galaxy.MVC.Filter.Exceptions;

namespace Galaxy.MVC.Filter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [RequiereHeader]
        public IActionResult RequiereHeader()
        {
            return View();
        }

        [ServiceFilter(typeof(TimerAction))]
        public IActionResult TimerAction()
        {
            return View();
        }
        [CustomExceptionFilter]
        public IActionResult Exception(int id)
        {
            switch (id)
            {
                case 1: throw new NoCreditException();
                case 2: throw new YouHaveExceededTheMountException();
                case 3: throw new Exception("No controlado");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
