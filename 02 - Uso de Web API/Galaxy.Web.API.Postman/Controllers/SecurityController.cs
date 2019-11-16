using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Web.API.Postman.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.Web.API.Postman.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        public JwtSettings _jwtSettings { get; set; }

        public SecurityController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public ActionResult<string> GenerateToken()
        {
            SecurityManager securityManager = new SecurityManager(_jwtSettings);

            return securityManager.BuildJwtToken();
        }
    }
}