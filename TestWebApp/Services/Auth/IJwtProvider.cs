using TestWebApp.Entity;

namespace TestWebApp.Services.Auth
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
