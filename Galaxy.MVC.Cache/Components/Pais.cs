using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Cache.Components
{
    public class Pais:ViewComponent
    {
        private readonly List<string> _paises;
        public Pais()
        {
            DateTime dateTime = DateTime.Now;
            _paises = new List<string> {
                dateTime.ToLongTimeString()+" - Perú",
                dateTime.ToLongTimeString()+" - Venezuela",
                dateTime.ToLongTimeString()+" - Colombia",
                dateTime.ToLongTimeString()+" - Argentina",
                dateTime.ToLongTimeString()+" - Brasil"
            };
        }

        public IViewComponentResult Invoke()
        {            
            return View(_paises);
        }
    }
}
