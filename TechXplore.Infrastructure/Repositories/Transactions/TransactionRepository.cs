using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.Repositories;
using TechXplore.Domain.Transactions;
using TechXplore.Persistence.Context;

namespace TechXplore.Infrastructure.Repositories.Transactions
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(TechXploreDBContext context) : base(context)
        {
        }

        public async Task Create(CancellationToken cancellationToken, Transaction transaction) => await base.AddAsync(cancellationToken, transaction);

        public async Task Delete(CancellationToken cancellationToken, int id) => await base.RemoveAsync(cancellationToken, id);
        public async Task<Transaction> Get(CancellationToken cancellationToken, int id) => await base.GetAsync(cancellationToken, id);
        public async Task Update(CancellationToken cancellationToken, Transaction transaction) => await base.UpdateAsync(cancellationToken, transaction);
    }
}
