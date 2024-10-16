using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Entity
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
