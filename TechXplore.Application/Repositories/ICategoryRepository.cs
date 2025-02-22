using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Categories;

namespace TechXplore.Application.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
        Task<Category> Get(CancellationToken cancellationToken, int id);
        Task Create(CancellationToken cancellationToken, Category category);
        Task Update(CancellationToken cancellationToken, Category category);
        Task Delete(CancellationToken cancellationToken, int id);
        public Task<Category> Get(CancellationToken cancellationToken, string name);
    }
}
