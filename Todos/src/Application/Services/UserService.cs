using Infrastructure.Clients;
using Todos.WebApi.Dtos;

namespace Todos.WebApi.Services
{
    public class UserService
    {
        private readonly IJsonPlaceholderClient _client;

        public UserService(IJsonPlaceholderClient client)
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
