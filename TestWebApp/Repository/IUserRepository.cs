using TestWebApp.Entity;

namespace TestWebApp.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task CreateUserAsync(User user, CancellationToken cancellationToken = default);
        Task<User?> GetUserAsync(string username, string password, CancellationToken cancellationToken = default);
    }
}
