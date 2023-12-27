using Todos.WebApi.Entities;

namespace Todos.WebApi.Repositories
{
    public interface ITodoRepository
    {
        Task Create(TodoEntity entity);
        Task<List<TodoEntity>> Get();
        Task<TodoEntity> Get(int id);
    }
}