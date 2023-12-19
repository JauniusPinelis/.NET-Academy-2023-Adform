namespace Todos.WebApi.Entities
{
    public class TodoEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public string LastModifiedBy { get; set; } = "Jaunius";
    }
}
