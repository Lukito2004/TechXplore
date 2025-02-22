using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.LimitModels;
using TechXplore.Application.Repositories;
using TechXplore.Application.UserModels;
using TechXplore.Domain.Categories;
using TechXplore.Domain.Limits;
using TechXplore.Domain.Users;

namespace TechXplore.Application.Services.Limits
{
    public class LimitService : ILimitService
    {
        private readonly ILimitRepository _limitRepository;
        private readonly ICategoryRepository _categoryRepository;
        public LimitService(ILimitRepository limitRepository, ICategoryRepository categoryRepository)
        {
            _limitRepository = limitRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<LimitResponseModel>> GetAllLimits(CancellationToken cancellationToken)
        {
            IEnumerable<Limit> limits = await _limitRepository.GetAllAsync(cancellationToken);
            return limits.Adapt<IEnumerable<LimitResponseModel>>();
        }
        public async Task<LimitResponseModel> GetLimit(CancellationToken cancellationToken, int id)
        {
            Limit limit = await _limitRepository.Get(cancellationToken, id);
            return limit.Adapt<LimitResponseModel>();
        }

        public async Task<LimitResponseModel> GetLimit(CancellationToken cancellationToken, string categoryName)
        {
            Category category = await _categoryRepository.Get(cancellationToken, categoryName);
            return await GetLimit(cancellationToken, category.Id);
        }
    }
}
