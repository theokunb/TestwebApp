using MediatR;
using TestWebApp.Repository;

namespace TestWebApp.Request
{
    public class GetTaskHandler : IRequestHandler<GetTask, Entity.MyTask>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskHandler(ITaskRepository dbContext)
        {
            _taskRepository = dbContext;
        }

        public async Task<Entity.MyTask> Handle(GetTask request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetTaskAsync(request.Id, cancellationToken);
        }
    }
}
