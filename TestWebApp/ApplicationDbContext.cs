using Microsoft.EntityFrameworkCore;
using TestWebApp.Entity;

namespace TestWebApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entity.MyTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
