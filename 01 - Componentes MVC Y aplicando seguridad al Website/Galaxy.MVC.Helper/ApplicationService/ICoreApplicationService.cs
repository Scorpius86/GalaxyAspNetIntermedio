using Galaxy.MVC.Helper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Helper.ApplicationService
{
    public interface ICoreApplicationService
    {
        List<Article> ListArticles();
    }
}
