using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechXplore.Application.Services.Users;
using TechXplore.Application.UserModels;

namespace TechXplore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<UserResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _userService.GetAllUsers(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<UserResponseModel> GetUser(CancellationToken cancellationToken, int id)
        {
            return await _userService.GetUser(cancellationToken, id);
        }
    }
}
