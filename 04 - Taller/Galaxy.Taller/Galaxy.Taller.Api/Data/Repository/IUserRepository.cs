using System.Collections.Generic;
using Galaxy.Taller.Api.Models;

namespace Galaxy.Taller.Api.Data.Repository
{
    public interface IUserRepository
    {
        UserDto GetUser(int userId);
        List<UserDto> GetUsers();
    }
}