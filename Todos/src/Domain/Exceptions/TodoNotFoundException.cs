namespace Todos.WebApi.Exceptions
{
    public class TodoNotFoundException : Exception
    {
        public TodoNotFoundException() : base("Todo was not found")
        {
            
        }
    }
}
