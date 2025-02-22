using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Rents;

namespace TechXplore.Application.Repositories
{
    public interface IRentRepository
    {
        Task<IEnumerable<Rent>> GetAllAsync(CancellationToken cancellationToken);
        Task<Rent> Get(CancellationToken cancellationToken, int id);
        Task Create(CancellationToken cancellationToken, Rent rent);
        Task Update(CancellationToken cancellationToken, Rent rent);
        Task Delete(CancellationToken cancellationToken, int id);
    }
}
