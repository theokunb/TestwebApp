using MediatR;
using TestWebApp.Entity;

namespace TestWebApp.Request.Books
{
    public class CreateBookRequest : IRequest<Book>
    {
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
