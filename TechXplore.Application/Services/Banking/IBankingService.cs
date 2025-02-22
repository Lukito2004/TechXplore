using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.LimitModels;
using TechXplore.Application.TransactionModels;
using TechXplore.Application.UserModels;

namespace TechXplore.Application.Services.Banking
{
    public interface IBankingService
    {
        public Task<bool> BuyAProduct(CancellationToken cancellationToken, UserRequestPostModel user, TransactionPostModel transaction);
        public Task<decimal> GetLimitProcentage(CancellationToken cancellationToken, UserRequestPostModel user, int limitId);
        public Task SetLimit(CancellationToken cancellationToken, LimitPostModel limit);
        public Task UpdateLimit(CancellationToken cancellationToken, LimitPostModel limit);
        public Task<decimal> GetLimitProcentage(CancellationToken cancellationToken, UserRequestPostModel user, string categoryName);
        public Task<decimal> GetMoneySpentInACertainCategory(CancellationToken cancellationToken, UserRequestPostModel user, int categoryId);
        public Task<decimal> GetMoneySpentInACertainCategory(CancellationToken cancellationToken, UserRequestPostModel user, string categoryName);


    }
}
