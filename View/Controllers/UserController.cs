using Microsoft.AspNetCore.Mvc;
using TechXplore.Application.Services.Users;

namespace View.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

    }
}
