using Galaxy.Taller.Api.Data.Repository;
using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public class UserApplicationService : IUserApplicationService
    {
        public IUserRepository _userRepository { get; set; }
        public UserApplicationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserDto> GetUsers()
        {
            return _userRepository.GetUsers();
        }
        public UserDto GetUser(int userId)
        {
            return _userRepository.GetUser(userId);
        }
    }
}
