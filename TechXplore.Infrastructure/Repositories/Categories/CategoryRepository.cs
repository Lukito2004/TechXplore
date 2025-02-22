using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.Repositories;
using TechXplore.Domain.Categories;
using TechXplore.Persistence.Context;

namespace TechXplore.Infrastructure.Repositories.Categories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TechXploreDBContext context) : base(context)
        {
        }

        public async Task Create(CancellationToken cancellationToken, Category category) => await base.AddAsync(cancellationToken, category);

        public async Task Delete(CancellationToken cancellationToken, int id) => await base.RemoveAsync(cancellationToken, id);
        public async Task<Category> Get(CancellationToken cancellationToken, int id) => await base.GetAsync(cancellationToken, id);
        public async Task<Category> Get(CancellationToken cancellationToken, string name) => await _dbSet.SingleOrDefaultAsync(x => x.Name == name, cancellationToken);

        public async Task Update(CancellationToken cancellationToken, Category category) => await base.UpdateAsync(cancellationToken, category);
    }
}
