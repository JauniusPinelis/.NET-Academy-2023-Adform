using Todos.WebApi.Dtos;

namespace Infrastructure.Clients
{
    public class JsonPlaceholderClient : IJsonPlaceholderClient
    {
        private HttpClient _httpClient;

        public JsonPlaceholderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            var users = await response.Content.ReadAsAsync<List<UserDto>>();

            return users;
        }

        public async Task<JsonPlaceholderResult<UserDto>> GetUserAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<UserDto>();

                return new JsonPlaceholderResult<UserDto>
                {
                    Data = data,
                    IsSuccessful = true,
                    ErrorMessage = ""
                };
            }
            else
            {
                return new JsonPlaceholderResult<UserDto>
                {
                    IsSuccessful = false,
                    ErrorMessage = response.StatusCode.ToString()
                };
            }
        }
    }
}
