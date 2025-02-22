using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Companies;

namespace TechXplore.Application.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllAsync(CancellationToken cancellationToken);
        Task<Company> Get(CancellationToken cancellationToken, int id);
        Task Create(CancellationToken cancellationToken, Company company);
        Task Update(CancellationToken cancellationToken, Company company);
        Task Delete(CancellationToken cancellationToken, int id);
    }
}
