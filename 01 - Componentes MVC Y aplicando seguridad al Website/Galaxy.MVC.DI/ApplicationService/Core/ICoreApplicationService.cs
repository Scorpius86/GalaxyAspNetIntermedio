using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.DI.ApplicationService.Core
{
    public interface ICoreApplicationService
    {
        string GetGuidTransient();
        string GetGuidScoped();
        string GetGuidSingleton();
    }
}
