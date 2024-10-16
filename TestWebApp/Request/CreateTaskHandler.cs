using AutoMapper;
using MediatR;
using TestWebApp.Repository;

namespace TestWebApp.Request
{
    public class CreateTaskHandler : IRequestHandler<CreateTask, Entity.MyTask>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTaskHandler(ITaskRepository dbContext, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _taskRepository = dbContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Entity.MyTask> Handle(CreateTask request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<Entity.MyTask>(request);

            var created = await _taskRepository.CreateAsync(task, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return created;
        }
    }
}
