using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Request.Auth;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AuthController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("Login")]
        public async Task<string> LoginAsync(string login, string password)
        {
            return await _mediatr.Send(new LoginRequest { Login = login, Password = password });
        }

        [HttpPost("CreateUser")]
        public async Task CreateUserAsync([FromBody] CreateUserRequest createUserRequest)
        {
            await _mediatr.Send(createUserRequest);
        }
    }
}
