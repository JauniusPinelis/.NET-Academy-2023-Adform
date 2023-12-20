using System.Reflection.Metadata.Ecma335;
using Todos.WebApi.Dtos;
using Todos.WebApi.Entities;
using Todos.WebApi.Exceptions;
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

        public async Task<TodoDto> Get(int id)
        {
            var entity = await _todoRepository.Get(id);
            if (entity is null)
            {
                throw new TodoNotFoundException();
            }

            return new TodoDto { Id =  entity.Id, Title = entity.Title };

        }

        public async Task< List<TodoDto> > Get()
        {
            List<TodoDto> todoDtos1 =  new ();

            var todos = await _todoRepository.Get();

            var todoDtos = todos.Select(t => new TodoDto
            {
                Id = t.Id,
                Title = t.Title,
            }).ToList();

            return todoDtos;
        }

        public async Task Create(TodoDto todoDto)
        {
            var entity = new TodoEntity
            {
                Id = todoDto.Id,
                Title = todoDto.Title
            };

            await _todoRepository.Create(entity);
        }
    }
}
