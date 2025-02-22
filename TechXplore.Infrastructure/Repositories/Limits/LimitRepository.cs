using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.Repositories;
using TechXplore.Domain.Limits;
using TechXplore.Persistence.Context;

namespace TechXplore.Infrastructure.Repositories.Limits
{
    public class LimitRepository : BaseRepository<Limit>, ILimitRepository
    {
        public LimitRepository(TechXploreDBContext context) : base(context)
        {
        }

        public async Task Create(CancellationToken cancellationToken, Limit limit) => await base.AddAsync(cancellationToken, limit);
        public async Task Delete(CancellationToken cancellationToken, int id) => await base.RemoveAsync(cancellationToken, id);
        public async Task<Limit> Get(CancellationToken cancellationToken, int id) => await base.GetAsync(cancellationToken, id);
        public async Task Update(CancellationToken cancellationToken, Limit limit) => await base.UpdateAsync(cancellationToken, limit);
    }
}
