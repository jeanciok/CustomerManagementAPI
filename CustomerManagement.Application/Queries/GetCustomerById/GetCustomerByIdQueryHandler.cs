using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerRepository.GetByIdAsync(request.Id);

            if (customer == null)
            {
                return null;
            }

            CustomerViewModel customerViewModel = new(customer.Id, customer.Name, customer.PhoneNumber, customer.Cnpj, 
                customer.Cpf, customer.Rg, customer.Cep, customer.Street, customer.Number, customer.Additional, customer.Email, customer.Description, 
                customer.City, customer.CreatedAt, customer.UpdatedAt, new CustomerGroupViewModel(customer.Group.Id, customer.Group.Name));

            return customerViewModel;
        }
    }
}
