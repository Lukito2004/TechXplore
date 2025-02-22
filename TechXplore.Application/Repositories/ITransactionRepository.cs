using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Transactions;
using TechXplore.Domain.Users;

namespace TechXplore.Application.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken cancellationToken);
        Task<Transaction> Get(CancellationToken cancellationToken, int id);
        Task Create(CancellationToken cancellationToken, Transaction transaction);
        Task Update(CancellationToken cancellationToken, Transaction transaction);
        Task Delete(CancellationToken cancellationToken, int id);
    }
}
