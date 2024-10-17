using MediatR;
using TestWebApp.Entity;

namespace TestWebApp.Request.Books
{
    public record GetBooksRequest : IRequest<IEnumerable<Book>>
    {
    }
}
