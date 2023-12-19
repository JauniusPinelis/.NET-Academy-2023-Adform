using Microsoft.AspNetCore.Mvc;
using Todos.WebApi.Dtos;
using Todos.WebApi.Services;

namespace Todos.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{

    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public ActionResult Get()
    {
       return Ok(_todoService.Get());
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        return Ok(_todoService.Get(id));
    }

    [HttpPost]
    public ActionResult Create(TodoDto todoDto)
    {
        _todoService.Create(todoDto);
        return NoContent();
    }
}
