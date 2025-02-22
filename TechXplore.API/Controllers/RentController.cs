using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechXplore.Application.LimitModels;
using TechXplore.Application.RentModels;
using TechXplore.Application.Services.Limits;
using TechXplore.Application.Services.Rents;

namespace TechXplore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;
        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<RentResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _rentService.GetAllRent(cancellationToken);
        }

        [HttpGet("GetById/{id}")]
        public async Task<RentResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await _rentService.GetRent(cancellationToken, id);
        }

        [HttpGet("GetByName/{rentYear}/{rentMonth}")]
        public async Task<RentResponseModel> Get(CancellationToken cancellationToken, int rentYear, int rentMonth)
        {
            return await _rentService.GetRentByYearAndMonth(cancellationToken, rentYear, rentMonth);
        }
    }
}
