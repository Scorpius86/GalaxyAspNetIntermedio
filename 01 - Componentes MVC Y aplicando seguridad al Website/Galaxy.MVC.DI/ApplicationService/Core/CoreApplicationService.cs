using Galaxy.MVC.DI.ApplicationService.Scoped;
using Galaxy.MVC.DI.ApplicationService.Singleton;
using Galaxy.MVC.DI.ApplicationService.Transient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.DI.ApplicationService.Core
{
    public class CoreApplicationService:ICoreApplicationService
    {
        private IGuidTransientApplicationService _guidTransientApplicationService { get; }
        private IGuidScopedApplicationService _guidScopedApplicationService { get; }
        private IGuidSingletonApplicationService _guidSingletonApplicationService { get; }

        public CoreApplicationService(
            IGuidTransientApplicationService guidTransientApplicationService,
            IGuidScopedApplicationService guidScopedApplicationService,
            IGuidSingletonApplicationService guidSingletonApplicationService
            )
        {
            _guidTransientApplicationService = guidTransientApplicationService;
            _guidScopedApplicationService = guidScopedApplicationService;
            _guidSingletonApplicationService = guidSingletonApplicationService;
        }

        public string GetGuidTransient()
        {
            return _guidTransientApplicationService.GetGuid();
        }
        public string GetGuidScoped()
        {
            return _guidScopedApplicationService.GetGuid();
        }
        public string GetGuidSingleton()
        {
            return _guidSingletonApplicationService.GetGuid();
        }
    }
}
