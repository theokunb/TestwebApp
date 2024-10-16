using Microsoft.EntityFrameworkCore;
using TestWebApp.Entity;

namespace TestWebApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await _context.Set<User>().AddAsync(user, cancellationToken);
        }

        public async Task<User?> GetUserAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            return await _context
                .Set<User>()
                .FirstOrDefaultAsync(element => element.UserName == username && element.Password == password, cancellationToken);
        }
    }
}
