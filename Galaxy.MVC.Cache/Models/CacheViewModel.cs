using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Cache.Models
{
    public class CacheViewModel
    {
        public CacheViewModel()
        {
            InMemory = new List<string>();
            TagHelper = new List<string>();
            Distributed = new List<string>();
            Response = new List<string>();
        }
        public List<string> InMemory { get; set; }
        public List<string> TagHelper { get; set; }
        public List<string> Distributed { get; set; }
        public List<string> Response { get; set; }
    }
}
