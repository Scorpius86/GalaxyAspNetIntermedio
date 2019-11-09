using Galaxy.MVC.Helper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Helper.ApplicationService
{
    public class CoreApplicationService:ICoreApplicationService
    {
        private List<Article> articles = new List<Article>();
        public CoreApplicationService()
        {
            for (int i = 0; i < 2; i++)
            {
                articles.Add(new Article
                {
                    Title = "List group item heading",
                    LastTime = "3 days ago",
                    Body = "Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.",
                    Footer = "Donec id elit non mi porta."
                });
            }
        }

        public List<Article> ListArticles()
        {
            return articles;
        }
    }
}
