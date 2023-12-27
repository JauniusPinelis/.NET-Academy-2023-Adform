using Microsoft.AspNetCore.Mvc;
using Todos.WebApi.Services;

namespace Todos.WebApi.Controllers
{
    [ApiController()]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userService.GetById(id));
        }
    }
}
