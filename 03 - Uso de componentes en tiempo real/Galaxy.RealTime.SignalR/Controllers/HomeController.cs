using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Galaxy.RealTime.SignalR.Models;
using Galaxy.RealTime.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Galaxy.RealTime.SignalR.Controllers
{
    public class HomeController : Controller
    {
        public IHubContext<AuthorHub> _authorHub { get; set; }

        public HomeController(IHubContext<AuthorHub> authHub)
        {
            _authorHub = authHub;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MostrarMensaje()
        {
            await _authorHub.Clients.All.SendAsync("MostrarMensajeCliente");
            return Accepted(1);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
