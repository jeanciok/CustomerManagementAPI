using CustomerManagement.Application.Queries.GetAllCustomers;
using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.UnitTests.Application.Queries
{
    public class GetAllCustomersQueryHandlerTests
    {
        [Fact]
        public async Task ThreeCustomersExists_Executed_ReturnThreeCustomersCustomerViewModel()
        {

            // Arrange
            List<Customer> customers = new()
            {
                new Customer(Guid.NewGuid(), "John Doe", "123456789", "123456789", "22222222222", "333333333", "44444444", "1231231231", "Street 1", "1", "District 1", "Additional 1", "john.doe@example.com", "Description 1", Guid.NewGuid(), Guid.NewGuid()),
                new Customer(Guid.NewGuid(), "Jane Smith", "987654321", "987654321", "66666666666", "777777777", "88888888", "1231231231", "Street 2", "2", "District 1", "Additional 2", "jane.smith@example.com", "Description 2", Guid.NewGuid(), Guid.NewGuid()),
                new Customer(Guid.NewGuid(), "Bob Johnson", "555555555", "555555555", "88888888888", "777777777", "66666666", "12312312312", "Street 3", "3", "District 1", "Additional 3", "bob.johnson@example.com", "Description 3", Guid.NewGuid(), Guid.NewGuid())
            };

            Mock<ICustomerRepository> customerRepositoryMock = new();
            customerRepositoryMock.Setup(x => x.Get("", "", "")).ReturnsAsync(customers);

            GetAllCustomersQuery getAllCustomersQuery = new();
            GetAllCustomersQueryHandler getAllCustomersQueryHandler = new(customerRepositoryMock.Object);

            // Act
            List<CustomerViewModel> customerViewModels = await getAllCustomersQueryHandler.Handle(getAllCustomersQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(customerViewModels);
            Assert.NotEmpty(customerViewModels);
            Assert.Equal(3, customerViewModels.Count);

            customerRepositoryMock.Verify(x => x.Get("", "", ""), Times.Once);
        }

        [Fact]
        public async Task NoCustomersExist_Executed_ReturnEmptyList()
        {
            // Arrange
            Mock<ICustomerRepository> customerRepositoryMock = new();
            customerRepositoryMock.Setup(x => x.Get("", "", "")).ReturnsAsync(new List<Customer>());

            GetAllCustomersQuery getAllCustomersQuery = new();
            GetAllCustomersQueryHandler getAllCustomersQueryHandler = new(customerRepositoryMock.Object);

            // Act
            List<CustomerViewModel> customerViewModels = await getAllCustomersQueryHandler.Handle(getAllCustomersQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(customerViewModels);
            Assert.Empty(customerViewModels);

            customerRepositoryMock.Verify(x => x.Get("", "", ""), Times.Once);
        }

        //[Fact]
        //public async Task CustomerEntityToViewModelMapping_Executed_CorrectlyMapped()
        //{
        //    // Arrange
        //    Customer customer = new(Guid.NewGuid(), "John Doe", "123456789", "123456789", "22222222222", "333333333", "44444444", "1231231231", "Street 1", "1", "District 1", "Additional 1", "www.example.com", "Description 1", Guid.NewGuid(), Guid.NewGuid());

        //    Mock<ICustomerRepository> customerRepositoryMock = new();
        //    customerRepositoryMock.Setup(x => x.Get("", "", "")).ReturnsAsync(new List<Customer> { customer });

        //    GetAllCustomersQuery getAllCustomersQuery = new();
        //    GetAllCustomersQueryHandler getAllCustomersQueryHandler = new(customerRepositoryMock.Object);

        //    // Act
        //    List<CustomerViewModel> customerViewModels = await getAllCustomersQueryHandler.Handle(getAllCustomersQuery, CancellationToken.None);

        //    // Assert
        //    Assert.NotNull(customerViewModels);
        //    Assert.Single(customerViewModels);
        //    Assert.Equal(customer.Id, customerViewModels[0].Id);
        //    Assert.Equal(customer.Name, customerViewModels[0].Name);
        //    Assert.Equal(customer.PhoneNumber, customerViewModels[0].PhoneNumber);
        //    Assert.Equal(customer.Email, customerViewModels[0].Email);
        //    Assert.Equal(customer.Description, customerViewModels[0].Description);
        //    Assert.Equal(customer.Cpf, customerViewModels[0].CNPJ);
        //    Assert.Equal(customer.Rg, customerViewModels[0].RG);
        //    Assert.Equal(customer.Cep, customerViewModels[0].CEP);
        //    Assert.Equal(customer.Street, customerViewModels[0].Street);
        //    Assert.Equal(customer.Number, customerViewModels[0].Number);
        //    Assert.Equal(customer.Additional, customerViewModels[0].Additional);
        //    Assert.Equal(customer.City, customerViewModels[0].City);
        //    Assert.Equal(customer.CreatedAt, customerViewModels[0].CreatedAt);
        //    Assert.Equal(customer.UpdatedAt, customerViewModels[0].UpdatedAt);

        //    customerRepositoryMock.Verify(x => x.Get("", "", ""), Times.Once);
        //}

    }
}
