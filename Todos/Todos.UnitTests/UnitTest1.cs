using Todos.WebApi.Repositories;
using Todos.WebApi.Services;

namespace Todos.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // we want to check if the service applies the discount
            var todoRepository = new TodoRepository();
            var service = new TodoService(todoRepository);

            var result = service.Get();

            Assert.Equal(8.0M, result.Price);
        }
    }
}