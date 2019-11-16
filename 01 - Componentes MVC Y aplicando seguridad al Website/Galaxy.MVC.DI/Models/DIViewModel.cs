using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.DI.Models
{
    public class DIViewModel
    {
        public DIViewModel()
        {
            GuidTransient = new GuidViewModel();
            GuidScoped = new GuidViewModel();
            GuidSingleton = new GuidViewModel();
        }
        public GuidViewModel GuidTransient { get; set; }
        public GuidViewModel GuidScoped { get; set; }
        public GuidViewModel GuidSingleton { get; set; }
    }
}
