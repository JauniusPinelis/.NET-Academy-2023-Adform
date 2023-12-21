using Microsoft.EntityFrameworkCore;
using Todos.WebApi.Contexts;
using Todos.WebApi.Dtos;
using Todos.WebApi.Entities;

namespace Todos.WebApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;

        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TodoEntity>> Get()
        {
            var result = _dataContext.Todos.Where(x => x.Id > 20);

            result = result.Where(x => x.Id > 30);

            return await result.ToListAsync();
        }

        public async Task<TodoEntity> Get(int id)
        {
            return await _dataContext.Todos.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Create(TodoEntity entity)
        {
            _dataContext.Todos.Add(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
