namespace TestWebApp.Repository
{
    public interface ITaskRepository : IRepository<Entity.MyTask>
    {
        Task<Entity.MyTask?> GetTaskAsync(Guid id, CancellationToken cancellationToken);
        Task<Entity.MyTask?> CreateAsync(Entity.MyTask task, CancellationToken cancellationToken);
    }
}
