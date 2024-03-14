using CustomerManagement.Application.Commands.AddCustomer;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.UnitTests.Application.Commands
{
    public class CreateCustomerCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnCustomerId()
        {
            // Arrange
            var customerRepository = new Mock<ICustomerRepository>();

            var createCustomerCommandHandler = new CreateCustomerCommandHandler(customerRepository.Object);

            var createCustomerCommand = new CreateCustomerCommand
                ("Name", "CNPJ", "CPF", "RG", "PhoneNumber", "PhoneNumber2", "CEP", "Street", 1, "District 1",
                "Additional", Guid.NewGuid(), "Email", "Description", Guid.NewGuid());

            // Act
            var id = await createCustomerCommandHandler.Handle(createCustomerCommand, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, id);

            customerRepository.Verify(x => x.AddAsync(It.IsAny<Customer>()), Times.Once);
        }
    }
}
