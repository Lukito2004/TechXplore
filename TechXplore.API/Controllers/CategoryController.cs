using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechXplore.Application.CategoryModels;
using TechXplore.Application.LimitModels;
using TechXplore.Application.Services.Categories;
using TechXplore.Application.Services.Limits;

namespace TechXplore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<CategoryResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllCategories(cancellationToken);
        }

        [HttpGet("GetById/{id}")]
        public async Task<CategoryResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await _categoryService.GetCategory(cancellationToken, id);
        }

        [HttpGet("GetByName/{categoryName}")]
        public async Task<CategoryResponseModel> Get(CancellationToken cancellationToken, string categoryName)
        {
            return await _categoryService.GetCategory(cancellationToken, categoryName);
        }
    }
}
