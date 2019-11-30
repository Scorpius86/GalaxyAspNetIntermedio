using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Taller.Api.ApplicationServices;
using Galaxy.Taller.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.Taller.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserApplicationService _userApplicationService { get; set; }
        public UsersController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }
        [HttpGet]
        public ActionResult<List<UserDto>> GetUsers()
        {
            List<UserDto> users = _userApplicationService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDto> GetUser(int userId)
        {
            UserDto user = _userApplicationService.GetUser(userId);
            return Ok(user);
        }
    }
}