using AutoMapper;
using MediatR;
using TestWebApp.Entity;
using TestWebApp.Repository;

namespace TestWebApp.Request.Books
{
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, Book>
    {
        private readonly BooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public CreateBookHandler(BooksRepository booksService, IMapper mapper)
        {
            _booksRepository = booksService;
            _mapper = mapper;
        }

        public async Task<Book> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _booksRepository.CreateAsync(book, cancellationToken);

            return book;
        }
    }
}
