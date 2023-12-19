using System.Reflection.Metadata.Ecma335;
using Todos.WebApi.Dtos;
using Todos.WebApi.Entities;
using Todos.WebApi.Repositories;

namespace Todos.WebApi.Services
{
    public class TodoService
    {
        private readonly TodoRepository _todoRepository;

        public TodoService(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public TodoDto Get(int id)
        {
            var entity = _todoRepository.Get(id);
            if (entity is null)
            {
                throw new ArgumentNullException("todo not found");
            }

            return new TodoDto { Id =  entity.Id, Title = entity.Title };

        }

        public List<TodoDto> Get()
        {
            List<TodoDto> todoDtos1 =  new ();

            var todos = _todoRepository.Get();

            var todoDtos = todos.Select(t => new TodoDto
            {
                Id = t.Id,
                Title = t.Title,
            }).ToList();

            return todoDtos;
        }

        public void Create(TodoDto todoDto)
        {
            var entity = new TodoEntity
            {
                Id = todoDto.Id,
                Title = todoDto.Title
            };

            _todoRepository.Create(entity);
        }
    }
}
