using System.Collections.Generic;
using Galaxy.Taller.Api.Models;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public interface IClientApplicationService
    {
        ClientDto GetClient(int clientId);
        List<ClientDto> GetClients();
    }
}