using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechXplore.Application.LimitModels;
using TechXplore.Application.Services.Limits;

namespace TechXplore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitController : ControllerBase
    {
        private readonly ILimitService _limitService;
        public LimitController(ILimitService limitService)
        {
            _limitService = limitService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<LimitResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _limitService.GetAllLimits(cancellationToken);
        }

        [HttpGet("GetById/{id}")]
        public async Task<LimitResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await _limitService.GetLimit(cancellationToken, id);
        }

        [HttpGet("GetByName/{categoryName}")]
        public async Task<LimitResponseModel> Get(CancellationToken cancellationToken, string categoryName)
        {
            return await _limitService.GetLimit(cancellationToken, categoryName);
        }
    }
}
