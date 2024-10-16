using MediatR;

namespace TestWebApp.Request
{
    public class GetTask : IRequest<Entity.MyTask>
    {
        public Guid Id { get; set; }

        public GetTask()
        {
        }

        public GetTask(Guid id)
        {
            Id = id;
        }
    }
}
