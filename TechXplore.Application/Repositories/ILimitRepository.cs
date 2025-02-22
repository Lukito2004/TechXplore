using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Limits;

namespace TechXplore.Application.Repositories
{
    public interface ILimitRepository
    {
        Task<IEnumerable<Limit>> GetAllAsync(CancellationToken cancellationToken);
        Task<Limit> Get(CancellationToken cancellationToken, int id);
        Task Create(CancellationToken cancellationToken, Limit limit);
        Task Update(CancellationToken cancellationToken, Limit limit);
        Task Delete(CancellationToken cancellationToken, int id);
    }
}
