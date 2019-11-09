using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Galaxy.MVC.Cache.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace Galaxy.MVC.Cache.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;
        private readonly List<string> _paises;

        public HomeController(IMemoryCache memoryCache,IDistributedCache distributedCache)
        {
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;

            DateTime dateTime = DateTime.Now;
            _paises = new List<string> {
                dateTime.ToLongTimeString()+" - Perú",
                dateTime.ToLongTimeString()+" - Venezuela",
                dateTime.ToLongTimeString()+" - Colombia",
                dateTime.ToLongTimeString()+" - Argentina",
                dateTime.ToLongTimeString()+" - Brasil"
            };
        }

        [ResponseCache(CacheProfileName = "Default")]
        public IActionResult Index()
        {
            CacheViewModel cacheViewModel = new CacheViewModel();

            cacheViewModel.InMemory = _memoryCache.GetOrCreate("paises", entry =>{
                entry.SlidingExpiration = TimeSpan.FromSeconds(5);
                entry.Priority = CacheItemPriority.High;
                return _paises;
            });

            var paisesDC = _distributedCache.Get("paises");
            if(paisesDC == null)
            {
                _distributedCache.Set("paises",
                    Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_paises)),
                    new DistributedCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromSeconds(4)
                    }
               );

                cacheViewModel.Distributed = _paises;
            }
            else
            {
                cacheViewModel.Distributed = JsonConvert.DeserializeObject<List<string>>(Encoding.UTF8.GetString(_distributedCache.Get("paises"))); 
            }

            cacheViewModel.Response = _paises;
            return View(cacheViewModel);
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
