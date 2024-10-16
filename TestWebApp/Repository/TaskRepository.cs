using Microsoft.EntityFrameworkCore;

namespace TestWebApp.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Entity.MyTask?> CreateAsync(Entity.MyTask task, CancellationToken cancellationToken)
        {
            var res = await _dbContext.Set< Entity.MyTask>().AddAsync(task, cancellationToken);
            return res.Entity;
        }

        public async Task<Entity.MyTask?> GetTaskAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Entity.MyTask>().FirstOrDefaultAsync(element => element.Id == id, cancellationToken);
        }
    }
}
