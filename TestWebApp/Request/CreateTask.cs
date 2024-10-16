using MediatR;

namespace TestWebApp.Request
{
    public class CreateTask : IRequest<Entity.MyTask>
    {
        public string Header { get; set; }
        public string Description { get; set; }
    }
}
