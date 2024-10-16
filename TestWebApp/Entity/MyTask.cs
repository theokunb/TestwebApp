using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Entity
{
    public class MyTask : BaseEntity
    {
        public string Header { get; set; }
        public string Description { get; set; }
    }
}
