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
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public IClientApplicationService _clientApplicationService { get; set; }
        public ClientsController(IClientApplicationService clientApplicationService)
        {
            _clientApplicationService = clientApplicationService;
        }
        [HttpGet]
        public ActionResult<List<ClientDto>> GetClients()
        {
            List<ClientDto> clients = _clientApplicationService.GetClients();
            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        public ActionResult<ClientDto> GetClient(int clientId)
        {
            ClientDto client = _clientApplicationService.GetClient(clientId);
            return Ok(client);
        }
    }
}