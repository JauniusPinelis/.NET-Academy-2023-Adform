using Todos.WebApi.Dtos;

namespace Todos.WebApi.Clients
{
    public class JsonPlaceholderClient
    {
        private HttpClient _httpClient;

        public JsonPlaceholderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task< List<UserDto>> GetUsers()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            var users = await response.Content.ReadAsAsync<List<UserDto>>();

            return users;
        }
    }
}
