using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestWebApp.Entity;
using TestWebApp.Options;

namespace TestWebApp.Repository
{
    public class BooksRepository
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public BooksRepository(
            IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(
                bookStoreDatabaseSettings.Value.CollectionName);
        }

        public async Task<IEnumerable<Book>> GetAsync(CancellationToken cancellationToken = default) =>
            await _booksCollection.Find(_ => true).ToListAsync(cancellationToken);

        public async Task<Book?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

        public async Task CreateAsync(Book newBook, CancellationToken cancellationToken = default) =>
            await _booksCollection.InsertOneAsync(newBook, cancellationToken: cancellationToken);

        public async Task UpdateAsync(Guid id, Book updatedBook, CancellationToken cancellationToken = default) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook, cancellationToken: cancellationToken);

        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }
}
