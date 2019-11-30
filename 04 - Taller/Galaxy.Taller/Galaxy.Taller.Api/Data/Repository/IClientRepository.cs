using System.Collections.Generic;
using Galaxy.Taller.Api.Models;

namespace Galaxy.Taller.Api.Data.Repository
{
    public interface IClientRepository
    {
        ClientDto GetClient(int clientId);
        List<ClientDto> Getclients();
    }
}