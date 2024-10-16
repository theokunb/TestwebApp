using MediatR;

namespace TestWebApp.Request.Auth
{
    public class LoginRequest : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
