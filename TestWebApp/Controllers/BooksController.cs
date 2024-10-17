using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Entity;
using TestWebApp.Request.Books;

namespace TestWebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var books = await _mediator.Send(new GetBooksRequest());

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(Guid id)
        {
            var book = await _mediator.Send(new GetBookRequest(id));

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post(CreateBookRequest newBook)
        {
            var book = await _mediator.Send(newBook);

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Update(Guid id, UpdateBookRequest updatedBook)
        {
            var book = await _mediator.Send(new GetBookRequest(id));

            if(book is null)
            {
                return NotFound();
            }

            updatedBook.Id = id;
            book = await _mediator.Send(updatedBook);

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _mediator.Send(new GetBookRequest(id));

            if (book is null)
            {
                return NotFound();
            }

            await _mediator.Send(new DeleteBookRequest(id));

            return NoContent();
        }
    }
}
