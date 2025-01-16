using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly string _bucketUrl;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _bucketUrl = configuration["Storage:BucketURL"];
            
        }

        public async Task<CustomerViewModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerRepository.GetByIdAsync(request.Id);

            if (customer == null)
            {
                return null;
            }

            CustomerViewModel customerViewModel = new(customer.Id, customer.Name, customer.PhoneNumber, customer.PhoneNumber2, customer.Cpf != null ? customer.Cpf : customer.Cnpj, customer.Cep, customer.Street, customer.Number, customer.District, customer.Additional, customer.Email, customer.Description, 
                customer.City, customer.CreatedAt, customer.UpdatedAt, new CustomerGroupViewModel(customer.Group.Id, customer.Group.Name), $"{_bucketUrl}/{customer.AvatarUrl}");

            return customerViewModel;
        }
    }
}
