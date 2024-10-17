using MediatR;
using TestWebApp.Entity;

namespace TestWebApp.Request.Books
{
    public class GetBookRequest : IRequest<Book?>
    {
        public Guid Id { get; set; }

        public GetBookRequest(Guid id)
        {
            Id = id;
        }

        public GetBookRequest()
        {
            
        }
    }
}
