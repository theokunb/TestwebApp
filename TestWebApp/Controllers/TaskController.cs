using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Request;

namespace TestWebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<Entity.MyTask> GetAsync(Guid id)
        {
            return await _mediator.Send(new GetTask(id));
        }

        [HttpPost("Create")]
        public async Task<Entity.MyTask> CreateAsync([FromBody] CreateTask createTask)
        {
            return await _mediator.Send(createTask);
        }
    }
}
