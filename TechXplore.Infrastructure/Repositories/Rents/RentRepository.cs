using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.Repositories;
using TechXplore.Domain.Rents;
using TechXplore.Persistence.Context;

namespace TechXplore.Infrastructure.Repositories.Rents
{
    public class RentRepository : BaseRepository<Rent>, IRentRepository
    {
        public RentRepository(TechXploreDBContext context) : base(context)
        {
        }

        public async Task Create(CancellationToken cancellationToken, Rent rent) => await base.AddAsync(cancellationToken, rent);

        public async Task Delete(CancellationToken cancellationToken, int id) => await base.RemoveAsync(cancellationToken, id);
        public async Task<Rent> Get(CancellationToken cancellationToken, int id) => await base.GetAsync(cancellationToken, id);
        public async Task Update(CancellationToken cancellationToken, Rent rent) => await base.UpdateAsync(cancellationToken, rent);
    }
}
