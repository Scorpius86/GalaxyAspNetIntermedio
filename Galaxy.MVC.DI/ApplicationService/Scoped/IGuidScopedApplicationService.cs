using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.DI.ApplicationService.Scoped
{
    public interface IGuidScopedApplicationService
    {
        string GetGuid();
    }
}
