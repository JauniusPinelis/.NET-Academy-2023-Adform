using Microsoft.AspNetCore.Mvc;
using Todos.WebApi.Clients;

namespace Todos.WebApi.Controllers
{
    [ApiController()]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly JsonPlaceholderClient _client;

        public UserController(JsonPlaceholderClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _client.GetUsers());
        }
    }
}
