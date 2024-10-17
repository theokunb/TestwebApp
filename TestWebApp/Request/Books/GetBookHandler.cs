using MediatR;
using TestWebApp.Entity;
using TestWebApp.Repository;

namespace TestWebApp.Request.Books
{
    public class GetBookHandler : IRequestHandler<GetBookRequest, Book?>
    {
        private readonly BooksRepository _booksRepository;

        public GetBookHandler(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Book?> Handle(GetBookRequest request, CancellationToken cancellationToken) =>
            await _booksRepository.GetAsync(request.Id, cancellationToken);
    }
}
