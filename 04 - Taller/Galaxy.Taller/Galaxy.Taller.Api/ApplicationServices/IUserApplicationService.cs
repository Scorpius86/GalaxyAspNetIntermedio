using System.Collections.Generic;
using Galaxy.Taller.Api.Models;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public interface IUserApplicationService
    {
        UserDto GetUser(int userId);
        List<UserDto> GetUsers();
    }
}