using Galaxy.Taller.Api.Data.Repository;
using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public class ClientApplicationService : IClientApplicationService
    {
        public IClientRepository _clientRepository { get; set; }
        public ClientApplicationService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public List<ClientDto> GetClients()
        {
            return _clientRepository.Getclients();
        }
        public ClientDto GetClient(int clientId)
        {
            return _clientRepository.GetClient(clientId);
        }
    }
}
