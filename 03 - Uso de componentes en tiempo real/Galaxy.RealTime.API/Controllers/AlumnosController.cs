using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.RealTime.API.Services;
using Galaxy.RealTime.EF.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.RealTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private ILibraryRepository _libraryRepository;
        public AlumnosController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        [HttpGet()]
        public ActionResult<List<Alumno>> GetAlumnos()
        {
            List<Alumno> authorsRepo = _libraryRepository.GetAlumnos();
            return Ok(authorsRepo);
        }
    }
}