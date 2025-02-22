using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.Repositories;
using TechXplore.Domain.Companies;
using TechXplore.Persistence.Context;

namespace TechXplore.Infrastructure.Repositories.Companies
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(TechXploreDBContext context) : base(context)
        {
        }

        public async Task Create(CancellationToken cancellationToken, Company company) => await base.AddAsync(cancellationToken, company);

        public async Task Delete(CancellationToken cancellationToken, int id) => await base.RemoveAsync(cancellationToken, id);
        public async Task<Company> Get(CancellationToken cancellationToken, int id) => await base.GetAsync(cancellationToken, id);
        public async Task Update(CancellationToken cancellationToken, Company company) => await base.UpdateAsync(cancellationToken, company);
    }
}
