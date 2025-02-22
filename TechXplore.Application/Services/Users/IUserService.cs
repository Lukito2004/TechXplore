using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.UserModels;

namespace TechXplore.Application.Services.Users
{
    public interface IUserService
    {
        public Task<IEnumerable<UserResponseModel>> GetAllUsers(CancellationToken cancellationToken);
        public Task<UserResponseModel> GetUser(CancellationToken cancellationToken, int id);
    }
}
