using AutoMapper;
using MediatR;
using TestWebApp.Entity;
using TestWebApp.Repository;

namespace TestWebApp.Request.Books
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, Book>
    {
        private readonly BooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public UpdateBookHandler(BooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<Book> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _booksRepository.UpdateAsync(request.Id, book, cancellationToken);

            return book;
        }
    }
}
