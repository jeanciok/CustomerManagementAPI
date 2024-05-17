using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Application.Validators;
using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.UnitTests.Application.Commands.Validators
{
    public class CreateUserCommandValidatorTest
    {
        [Fact]
        public void InputDataIsOk_Validate_ShouldNotHaveValidationError()
        {
            // Arrange
            var validator = new CreateUserCommandValidator();
            var command = new CreateUserCommand
            {
                Name = "Jean Andrade",
                Email = "jean@example.com",
                Password = "password123",
                TenantId = Guid.NewGuid()
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
            var validator = new CreateUserCommandValidator();
            var command = new CreateUserCommand
            {
                Name = "",
                Email = "jean@example.com",
                Password = "password123",
                TenantId = Guid.NewGuid()
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Name is required");
        }

        [Fact]
        public void InvalidEmail_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateUserCommandValidator();
            var command = new CreateUserCommand
            {
                Name = "Jean Andrade",
                Email = "invalidemail",
                Password = "password123",
                TenantId = Guid.NewGuid()
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Email not valid");
        }

        [Theory]
        [InlineData("aaaaaa")]
        [InlineData("aaaaaa@")]
        [InlineData("@aaaaaa")]
        [InlineData("aaaaaaa.com")]
        public void InvalidEmails_Validate_ShouldHaveValidationError(string email)
        {
            // Arrange
            var validator = new CreateUserCommandValidator();
            var command = new CreateUserCommand
            {
                Name = "Jean Andrade",
                Email = email,
                Password = "password123",
                TenantId = Guid.NewGuid()
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Email not valid");
        }

        [Fact]
        public void EmptyPassword_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateUserCommandValidator();
            var command = new CreateUserCommand
            {
                Name = "Jean Andrade",
                Email = "jean@example.com",
                Password = "",
                TenantId = Guid.NewGuid()
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Password is required");
        }

        [Fact]
        public void Validate_EmptyTenantId_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateUserCommandValidator();
            var command = new CreateUserCommand
            {
                Name = "Jean Andrade",
                Email = "jean@example.com",
                Password = "password123",
                TenantId = Guid.Empty
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Tenant is required");
        }
    }
}
