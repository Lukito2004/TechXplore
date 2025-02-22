using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.Repositories;
using TechXplore.Domain.Users;
using TechXplore.Persistence.Context;

namespace TechXplore.Infrastructure.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TechXploreDBContext context) : base(context)
        {

        }

        public async Task Create(CancellationToken cancellationToken, User user) => await base.AddAsync(cancellationToken, user);

        public async Task Delete(CancellationToken cancellationToken, int id) => await base.RemoveAsync(cancellationToken, id);

        public async Task<User> Get(CancellationToken cancellationToken, int id)
        {
            return await _dbSet.Include(x => x.Transactions).Include(x => x.Limits).Include(x => x.Rents).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbSet.Include(x => x.Transactions).Include(x => x.Limits).Include(x => x.Rents).ToListAsync();
        }

        public async Task Update(CancellationToken cancellationToken, User user) => await base.UpdateAsync(cancellationToken, user);
        public void DetachAllUsers()
        {
            var userEntries = _context.ChangeTracker.Entries<User>();
            foreach (var entry in userEntries)
                entry.State = EntityState.Detached;
        }

        public void DetachACertainUser(int id)
        {
            var userEntry = _context.ChangeTracker.Entries<User>().SingleOrDefault(x => x.Entity.Id == id);
            userEntry.State = EntityState.Detached;
        }
    }
}
