using Microsoft.EntityFrameworkCore;
using Todos.WebApi.Contexts;
using Todos.WebApi.Dtos;
using Todos.WebApi.Entities;

namespace Todos.WebApi.Repositories
{
    public class TodoRepository
    {
        private readonly DataContext _dataContext;

        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<TodoEntity> Get()
        {
            return _dataContext.Todos.ToList();
        }

        public TodoEntity Get(int id)
        {
            return _dataContext.Todos.FirstOrDefault(t => t.Id == id);
        }

        public void Create(TodoEntity entity)
        {
            _dataContext.Todos.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
