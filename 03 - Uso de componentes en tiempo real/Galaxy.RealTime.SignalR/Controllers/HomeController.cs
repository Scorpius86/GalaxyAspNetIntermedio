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
        private readonly IHubContext<AuthorHub> _authorHub;
        public HomeController(IHubContext<AuthorHub> authorHub)
        {
            _authorHub = authorHub;
        }

        public async Task<IActionResult> Mensaje()
        {
            await _authorHub.Clients.All.SendAsync("MostrarMensaje", new { nemsaje = "text"});
            return Accepted(1);
        }
        public IActionResult Index()
        {
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
