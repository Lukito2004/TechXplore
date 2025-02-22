using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.Repositories;
using TechXplore.Application.UserModels;
using TechXplore.Domain.Users;

namespace TechXplore.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers(CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _userRepository.GetAll(cancellationToken);
            return users.Adapt<IEnumerable<UserResponseModel>>();
        }

        public async Task<UserResponseModel> GetUser(CancellationToken cancellationToken, int id)
        {
            User user = await _userRepository.Get(cancellationToken, id);
            return user.Adapt<UserResponseModel>();
        }
    }
}
