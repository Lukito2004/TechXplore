using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.LimitModels;

namespace TechXplore.Application.Services.Limits
{
    public interface ILimitService
    {
        public Task<IEnumerable<LimitResponseModel>> GetAllLimits(CancellationToken cancellationToken);
        public Task<LimitResponseModel> GetLimit(CancellationToken cancellationToken, int id);
        public Task<LimitResponseModel> GetLimit(CancellationToken cancellationToken, string categoryName);

    }
}
