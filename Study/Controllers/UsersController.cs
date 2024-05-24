using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Study.Application.Authentication;
using Study.Contracts.User;

namespace Study.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            await _usersService.Register(request.UserName, request.Email, request.Password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserRequest request,
            [FromServices] IHttpContextAccessor httpContextAccessor)
        {
            var context = httpContextAccessor.HttpContext;

            var token = await _usersService.Login(request.Email, request.Password);
            context!.Response.Cookies.Append("secretCookie", token);
            return Ok();
        }
    }
}
