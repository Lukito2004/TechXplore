using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.CategoryModels;

namespace TechXplore.Application.Services.Categories
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryResponseModel>> GetAllCategories(CancellationToken cancellationToken);
        public Task<CategoryResponseModel> GetCategory(CancellationToken cancellationToken, int id);
        public Task<CategoryResponseModel> GetCategory(CancellationToken cancellationToken, string categoryName);


    }
}
