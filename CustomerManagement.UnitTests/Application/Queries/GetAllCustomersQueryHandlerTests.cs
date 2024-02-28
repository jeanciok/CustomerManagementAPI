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
                new Customer(Guid.NewGuid(), "John Doe", new DateTime(1990, 1, 1), "123456789", "987654321", "11111111111", "22222222222", "333333333", "44444444", "1231231231", "Street 1", 1, "Additional 1", "john.doe@example.com", "www.example.com", "Description 1", "url1.jpg", Guid.NewGuid(), Guid.NewGuid()),
                new Customer(Guid.NewGuid(), "Jane Smith", new DateTime(1985, 5, 5), "987654321", "123456789", "55555555555", "66666666666", "777777777", "88888888", "1231231231", "Street 2", 2, "Additional 2", "jane.smith@example.com", "www.example.com", "Description 2", "url2.jpg", Guid.NewGuid(), Guid.NewGuid()),
                new Customer(Guid.NewGuid(), "Bob Johnson", new DateTime(1978, 10, 10), "555555555", "999999999", "99999999999", "88888888888", "777777777", "66666666","12312312312" ,"Street 3", 3, "Additional 3", "bob.johnson@example.com", "www.example.com", "Description 3", "url3.jpg", Guid.NewGuid(), Guid.NewGuid())
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

        [Fact]
        public async Task CustomerEntityToViewModelMapping_Executed_CorrectlyMapped()
        {
            // Arrange
            Customer customer = new(Guid.NewGuid(), "John Doe", new DateTime(1990, 1, 1), "123456789", "987654321", "11111111111", "22222222222", "333333333", "44444444", "1231231231", "Street 1", 1, "Additional 1", "john.doe@example.com", "www.example.com", "Description 1", "url1.jpg", Guid.NewGuid(), Guid.NewGuid());

            Mock<ICustomerRepository> customerRepositoryMock = new();
            customerRepositoryMock.Setup(x => x.Get("", "", "")).ReturnsAsync(new List<Customer> { customer });

            GetAllCustomersQuery getAllCustomersQuery = new();
            GetAllCustomersQueryHandler getAllCustomersQueryHandler = new(customerRepositoryMock.Object);

            // Act
            List<CustomerViewModel> customerViewModels = await getAllCustomersQueryHandler.Handle(getAllCustomersQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(customerViewModels);
            Assert.Single(customerViewModels);
            Assert.Equal(customer.Id, customerViewModels[0].Id);
            Assert.Equal(customer.Name, customerViewModels[0].Name);
            Assert.Equal(customer.BirthDate, customerViewModels[0].BirthDate);
            Assert.Equal(customer.PhoneNumber, customerViewModels[0].PhoneNumber);
            Assert.Equal(customer.Email, customerViewModels[0].Email);
            Assert.Equal(customer.Site, customerViewModels[0].Site);
            Assert.Equal(customer.Description, customerViewModels[0].Description);
            Assert.Equal(customer.URLPicture, customerViewModels[0].URLPicture);
            Assert.Equal(customer.CNPJ, customerViewModels[0].CNPJ);
            Assert.Equal(customer.CPF, customerViewModels[0].CPF);
            Assert.Equal(customer.RG, customerViewModels[0].RG);
            Assert.Equal(customer.CEP, customerViewModels[0].CEP);
            Assert.Equal(customer.Street, customerViewModels[0].Street);
            Assert.Equal(customer.Number, customerViewModels[0].Number);
            Assert.Equal(customer.Additional, customerViewModels[0].Additional);
            Assert.Equal(customer.City, customerViewModels[0].City);
            Assert.Equal(customer.CreatedAt, customerViewModels[0].CreatedAt);
            Assert.Equal(customer.UpdatedAt, customerViewModels[0].UpdatedAt);

            customerRepositoryMock.Verify(x => x.Get("", "", ""), Times.Once);
        }

    }
}
