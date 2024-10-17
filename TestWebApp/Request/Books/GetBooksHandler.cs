using MediatR;
using TestWebApp.Entity;
using TestWebApp.Repository;

namespace TestWebApp.Request.Books
{
    public class GetBooksHandler : IRequestHandler<GetBooksRequest, IEnumerable<Book>>
    {
        private readonly BooksRepository _booksRepository;

        public GetBooksHandler(BooksRepository booksRepository) =>
            _booksRepository = booksRepository;

        public async Task<IEnumerable<Book>> Handle(GetBooksRequest request, CancellationToken cancellationToken) =>
            await _booksRepository.GetAsync(cancellationToken);
    }
}
