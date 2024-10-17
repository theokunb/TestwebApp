using MediatR;

namespace TestWebApp.Request.Books
{
    public class DeleteBookRequest : IRequest
    {
        public Guid Id { get; set; }

        public DeleteBookRequest(Guid id)
        {
            Id = id;
        }

        public DeleteBookRequest()
        {

        }
    }
}
