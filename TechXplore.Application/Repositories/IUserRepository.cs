using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Users;

namespace TechXplore.Application.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken);
        Task<User> Get(CancellationToken cancellationToken, int id);
        Task Create(CancellationToken cancellationToken, User user);
        Task Update(CancellationToken cancellationToken, User user);
        Task Delete(CancellationToken cancellationToken, int id);
        public void DetachAllUsers();
        public void DetachACertainUser(int id);
    }
}
