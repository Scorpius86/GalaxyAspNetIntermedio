using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        public GalaxyTallerContext _galaxyTallerContext { get; set; }
        public ClientRepository(GalaxyTallerContext galaxyTallerContext)
        {
            _galaxyTallerContext = galaxyTallerContext;
        }

        private IQueryable<ClientDto> QueryGetClient(int clientId=0)
        {
            var query = from c in _galaxyTallerContext.Cliente
                        select new ClientDto
                        {
                            ClientId = c.ClienteId,
                            LastName = c.ApellidoPaterno,
                            SurName = c.ApellidoMaterno,
                            Name = c.Nombre,
                            FullName = c.Nombre + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno,
                            Age = c.Edad,
                            SexDescription = c.Sexo.Descripcion
                        };

            if (clientId != 0)
            {
                query = query.Where(w => w.ClientId == clientId);
            }

            return query;
        }
        public List<ClientDto> Getclients()
        {
            List<ClientDto> result = QueryGetClient().ToList();
            return result;
        }
        public ClientDto GetClient(int clientId)
        {
            ClientDto result = QueryGetClient(clientId).FirstOrDefault();
            return result;
        }
    }
}
