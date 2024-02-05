using CustomerManagement.Application.Commands.CreateTenant;
using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Application.Validators;
using Xunit;

namespace CustomerManagement.UnitTests.Application.Commands.Validators
{
    public class CreateTenantCommandValidatorTest
    {
        [Fact]
        public void InputDataIsOk_Validate_ShouldNotHaveValidationError()
        {
            // Arrange
            var validator = new CreateTenantCommandValidator();
            var command = new CreateTenantCommand
            {
                Name = "Tenant 1",
                DocumentNumber = "123456789",
                User = new CreateUserCommand()
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void EmptyName_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateTenantCommandValidator();
            var command = new CreateTenantCommand
            {
                Name = "",
                DocumentNumber = "123456789",
                User = new CreateUserCommand { /* preencha com dados válidos */ }
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Name is required");
        }

        [Fact]
        public void EmptyDocumentNumber_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateTenantCommandValidator();
            var command = new CreateTenantCommand
            {
                Name = "Tenant 1",
                DocumentNumber = "",
                User = new CreateUserCommand { /* preencha com dados válidos */ }
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "DocumentNumber is required");
        }
    }
}
