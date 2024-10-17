using MongoDB.Bson.Serialization.Attributes;

namespace TestWebApp.Entity
{
    public class Book
    {
        [BsonId]        
        public Guid Id {  get; set; }
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
