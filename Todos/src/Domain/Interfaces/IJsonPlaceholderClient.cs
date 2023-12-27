using Todos.WebApi.Dtos;

namespace Infrastructure.Clients
{
    public interface IJsonPlaceholderClient
    {
        Task<JsonPlaceholderResult<UserDto>> GetUserAsync(int userId);
        Task<List<UserDto>> GetUsers();
    }
}