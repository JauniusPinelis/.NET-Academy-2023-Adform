using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.WebApi.Entities;
using Todos.WebApi.Exceptions;
using Todos.WebApi.Repositories;
using Todos.WebApi.Services;

namespace Todos.UnitTests.Services
{
    public class TodoServiceTests
    {
        private readonly Mock<ITodoRepository> _todoRepositoryMock;

        private readonly TodoService _todoService;

        private readonly Fixture _fixture;

        public TodoServiceTests()
        {
            _todoRepositoryMock = new Mock<ITodoRepository>();
            _todoService = new TodoService( _todoRepositoryMock.Object );
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Get_GivenValidId_ReturnsDto()
        {
            //Arrange
            int id = _fixture.Create<int>();

            _todoRepositoryMock.Setup(m => m.Get(id)).ReturnsAsync(new TodoEntity()
            {
                Id = id
            });

            // Act
            var result = await _todoService.Get(id);

            // Assert
            _todoRepositoryMock.Verify(x => x.Get(It.IsAny<int>()), Times.Once);

            result.Id.Should().Be(id);
        }

        [Fact]
        public async Task Get_GivenInvalidId_ThrowsItemNotFoundException() {
            // Arrange
            int id = 1;

            _todoRepositoryMock.Setup(m => m.Get(id)).Returns(Task.FromResult<TodoEntity>(null));

            // Act Assert
            await Assert.ThrowsAsync<TodoNotFoundException>(async () => await _todoService.Get(id));
        }

        [Theory]
        [AutoData]
        public async Task TheoryTest(TodoEntity entity)
        {
            //Arrange

            _todoRepositoryMock.Setup(m => m.Get(entity.Id)).ReturnsAsync(
                entity
                );

            // Act
            var result = await _todoService.Get(entity.Id);

            // Assert
            _todoRepositoryMock.Verify(x => x.Get(entity.Id), Times.Once);

            result.Id.Should().Be(entity.Id);
        }
    }
}
