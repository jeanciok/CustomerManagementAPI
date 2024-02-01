using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_ValidData_ReturnsUserId()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();

            var createUserCommandHandler = new CreateUserCommandHandler(userRepository.Object, authService.Object);

            var createUserCommand = new CreateUserCommand
            {
                Name = "Jean Andrade",
                Email = "jean@example.com",
                Password = "password",
                TenantId = Guid.NewGuid()
            };

            // Act
            var id = await createUserCommandHandler.Handle(createUserCommand, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, id);

            userRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
