using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public GalaxyTallerContext _galaxyTallerContext { get; set; }
        public UserRepository(GalaxyTallerContext galaxyTallerContext)
        {
            _galaxyTallerContext = galaxyTallerContext;
        }

        private IQueryable<UserDto> QueryGetUser(int userId=0)
        {
            var query = from u in _galaxyTallerContext.Usuario
                        select new UserDto
                        {
                            UserId = u.UsuarioId,
                            UserName = u.NombreUsuario,
                            LastName = u.ApellidoPaterno,
                            SurName = u.ApellidoMaterno,
                            Name = u.Nombre,
                            FullName = u.Nombre + " " + u.ApellidoPaterno + " " + u.ApellidoMaterno,
                            Age = u.Edad,
                            SexDescription = u.Sexo.Descripcion
                        };

            if (userId != 0)
            {
                query = query.Where(w => w.UserId == userId);
            }

            return query;
        }
        public List<UserDto> GetUsers()
        {
            List<UserDto> result = QueryGetUser().ToList();
            return result;
        }
        public UserDto GetUser(int userId)
        {
            UserDto result = QueryGetUser(userId).FirstOrDefault();
            return result;
        }
    }
}
