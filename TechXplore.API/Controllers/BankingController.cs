using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechXplore.Application.LimitModels;
using TechXplore.Application.Services.Banking;
using TechXplore.Application.Services.Users;
using TechXplore.Application.TransactionModels;
using TechXplore.Application.UserModels;

namespace TechXplore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IBankingService _bankingService;
        private readonly IUserService _userService;
        public BankingController(IBankingService bankingService, IUserService userService)
        {
            _bankingService = bankingService;
            _userService = userService;
        }

        [HttpPost("InsertLimit")]
        public async Task InsertLimit(CancellationToken cancellationToken, LimitPostModel limit)
        {
            await _bankingService.SetLimit(cancellationToken, limit);
        }

        [HttpPut("UpdateLimit")]
        public async Task UpdateLimit(CancellationToken cancellationToken, LimitPostModel limit)
        {
            await _bankingService.UpdateLimit(cancellationToken, limit);
        }

        [HttpPost("BuySomething")]
        public async Task<bool> BuySomething(CancellationToken cancellationToken, TransactionPostModel transaction)
        {
            return await _bankingService.BuyAProduct(cancellationToken, (await _userService.GetUser(cancellationToken, 1)).Adapt<UserRequestPostModel>(), transaction);
        }

        [HttpGet("GetProcentage/{categoryId}")]
        public async Task<decimal> GetProcentage(CancellationToken cancellationToken, int categoryId)
        {
            UserRequestPostModel neededUser = (await _userService.GetUser(cancellationToken, 1)).Adapt<UserRequestPostModel>();
            return await _bankingService.GetLimitProcentage(cancellationToken, neededUser, categoryId);
        }

        [HttpGet("GetProcentageByName/{categoryName}")]
        public async Task<decimal> GetProcentage(CancellationToken cancellationToken, string categoryName)
        {
            UserRequestPostModel neededUser = (await _userService.GetUser(cancellationToken, 1)).Adapt<UserRequestPostModel>();
            return await _bankingService.GetLimitProcentage(cancellationToken, neededUser, categoryName);
        }

        [HttpGet("GetMoneySpentInCategory/{categoryId}")]
        public async Task<decimal> GetMoneySpentInCategory(CancellationToken cancellationToken, int categoryId)
        {
            UserRequestPostModel neededUser = (await _userService.GetUser(cancellationToken, 1)).Adapt<UserRequestPostModel>();
            return await _bankingService.GetMoneySpentInACertainCategory(cancellationToken, neededUser, categoryId);
        }

        [HttpGet("GetMoneySpentInCategoryByName/{categoryName}")]
        public async Task<decimal> GetMoneySpentInCategory(CancellationToken cancellationToken, string categoryName)
        {
            UserRequestPostModel neededUser = (await _userService.GetUser(cancellationToken, 1)).Adapt<UserRequestPostModel>();
            return await _bankingService.GetMoneySpentInACertainCategory(cancellationToken, neededUser, categoryName);
        }
    }
}
