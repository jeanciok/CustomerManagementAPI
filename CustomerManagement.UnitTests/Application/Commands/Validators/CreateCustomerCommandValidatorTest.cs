using CustomerManagement.Application.Commands.AddCustomer;
using CustomerManagement.Application.Validators;
using System;
using Xunit;

namespace CustomerManagement.UnitTests.Application.Commands.Validators
{
    public class CreateCustomerCommandValidatorTest
    {
        [Fact]
        public void InputDataIsOk_Validate_ShouldNotHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void NameIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Name" && e.ErrorMessage == "Name is required");
        }

        [Fact]
        public void HomePhoneIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "HomePhone" && e.ErrorMessage == "Home phone is required");
        }

        [Fact]
        public void CNPJIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "CNPJ" && e.ErrorMessage == "CNPJ is required");
        }

        [Fact]
        public void CPFIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "CPF" && e.ErrorMessage == "CPF is required");
        }



        [Fact]
        public void AdditionalIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Additional" && e.ErrorMessage == "Additional information is required");
        }

        [Fact]
        public void RGIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "RG" && e.ErrorMessage == "RG is required");
        }

        [Fact]
        public void CEPIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "CEP" && e.ErrorMessage == "CEP is required");
        }

        [Fact]
        public void StreetIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Street" && e.ErrorMessage == "Street is required");
        }

        [Fact]
        public void NumberIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 0,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Number" && e.ErrorMessage == "Number is required");
        }

        [Fact]
        public void GroupIdIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.Empty,
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "GroupId" && e.ErrorMessage == "Group ID is required");
        }

        [Fact]
        public void EmailIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Email" && e.ErrorMessage == "Email is not valid");
        }

        [Fact]
        public void SiteIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Site" && e.ErrorMessage == "Site is required");
        }

        [Fact]
        public void DescriptionIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.NewGuid()
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Description" && e.ErrorMessage == "Description is required");
        }

        [Fact]
        public void CityIdIsEmpty_Validate_ShouldHaveValidationError()
        {
            // Arrange
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand(
                name: "Jean Andrade",
                phoneNumber: "1234567890",
                businessPhone: "0987654321",
                homePhone: "9876543210",
                cNPJ: "12345678901234",
                cPF: "12345678901",
                rG: "123456789",
                cEP: "12345-678",
                street: "Example Street",
                number: 123,
                additional: "Apartment 42",
                groupId: Guid.NewGuid(),
                email: "jean@example.com",
                site: "www.example.com",
                description: "Lorem ipsum dolor sit amet",
                uRLPicture: "https://example.com/picture.jpg",
                cityId: Guid.Empty
            );

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "CityId" && e.ErrorMessage == "City ID is required");
        }
    }
}
