using Galaxy.MVC.Helper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Helper.Models
{
    public class HelperViewModel
    {
        public List<Article> ArticlesStringBuilder { get; set; }
        public List<Article> ArticlesTagBuilder { get; set; }
        public List<Article> ArticlesTagHelper { get; set; }

        public HelperViewModel()
        {
            ArticlesStringBuilder = new List<Article>();
            ArticlesTagBuilder = new List<Article>();
            ArticlesTagHelper = new List<Article>();
        }
    }
}
