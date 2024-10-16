using MediatR;

namespace TestWebApp.Request.Auth
{
    public class CreateUserRequest : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
