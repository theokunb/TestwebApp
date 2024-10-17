using MediatR;
using TestWebApp.Repository;

namespace TestWebApp.Request.Books
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest>
    {
        private readonly BooksRepository _bookRepository;

        public DeleteBookHandler(BooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            await _bookRepository.RemoveAsync(request.Id, cancellationToken);
        }
    }
}
