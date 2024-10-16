using MediatR;
using TestWebApp.Repository;
using TestWebApp.Services.Auth;

namespace TestWebApp.Request.Auth
{
    public class LoginHandler : IRequestHandler<LoginRequest, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.Login, request.Password);

            if (user == null)
            {
                throw new ArgumentException("incorrect login");
            }

            string token = _jwtProvider.Generate(user);

            return token;
        }
    }
}
