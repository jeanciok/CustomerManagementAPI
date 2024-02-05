using CustomerManagement.Application.Commands.CreateCustomerGroup;
using CustomerManagement.Application.Validators;
using Xunit;

namespace CustomerManagement.UnitTests.Application.Commands.Validators
{
    public class CreateCustomerGroupCommandValidatorTest
    {
        [Fact]
        public void InputDataIsOk_Validate_ShouldNotHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerGroupCommandValidator();
            var command = new CreateCustomerGroupCommand
            {
                Name = "Group 1"
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
            var validator = new CreateCustomerGroupCommandValidator();
            var command = new CreateCustomerGroupCommand
            {
                Name = ""
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Name is required");
        }
    }
}
