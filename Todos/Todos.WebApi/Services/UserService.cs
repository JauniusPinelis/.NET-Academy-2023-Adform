using Todos.WebApi.Clients;
using Todos.WebApi.Dtos;

namespace Todos.WebApi.Services
{
    public class UserService
    {
        private readonly JsonPlaceholderClient _client;

        public UserService(JsonPlaceholderClient client)
        {
            _client = client;
        }

        public async Task<UserDto> GetById(int id)
        {
            var result = await _client.GetUserAsync(id);

            if (!result.IsSuccessful)
                throw new Exception("user not found");

            return result.Data!;
        }
    }
}
