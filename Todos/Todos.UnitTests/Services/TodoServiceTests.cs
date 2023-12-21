using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.WebApi.Contexts;
using Todos.WebApi.Entities;
using Todos.WebApi.Exceptions;
using Todos.WebApi.Repositories;
using Todos.WebApi.Services;

namespace Todos.UnitTests.Services
{
    public class TodoServiceTests
    {
        [Fact]
        public async Task Get_GivenValidId_ReturnsDto()
        {
            //Arrange
            int id = 1;

            var testRepository = new Mock<ITodoRepository>();
            testRepository.Setup(m => m.Get(id)).ReturnsAsync(new WebApi.Entities.TodoEntity()
            {
                Id = id
            });

            var todoService = new TodoService(testRepository.Object);

            // Act
            var result = await todoService.Get(id);

            // Assert
            result.Id.Should().Be(id);
        }

        [Fact]
        public async Task Get_GivenInvalidId_ThrowsItemNotFoundException() {
            // Arrange
            int id = 1;
            var testRepository = new Mock<ITodoRepository>();
            testRepository.Setup(m => m.Get(id)).Returns(Task.FromResult<TodoEntity>(null));

            var todoService = new TodoService(testRepository.Object);

            // Act Assert
            await Assert.ThrowsAsync<TodoNotFoundException>(async () => await todoService.Get(id));
        }
    }
}
