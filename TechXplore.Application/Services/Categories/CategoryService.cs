using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.CategoryModels;
using TechXplore.Application.LimitModels;
using TechXplore.Application.Repositories;
using TechXplore.Domain.Categories;
using TechXplore.Domain.Limits;

namespace TechXplore.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAllCategories(CancellationToken cancellationToken)
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync(cancellationToken);
            return categories.Adapt<IEnumerable<CategoryResponseModel>>();
        }
        public async Task<CategoryResponseModel> GetCategory(CancellationToken cancellationToken, int id)
        {
            Category category = await _categoryRepository.Get(cancellationToken, id);
            return category.Adapt<CategoryResponseModel>();
        }

        public async Task<CategoryResponseModel> GetCategory(CancellationToken cancellationToken, string categoryName)
        {
            Category category = await _categoryRepository.Get(cancellationToken, categoryName);
            return category.Adapt<CategoryResponseModel>();
        }
    }
}
