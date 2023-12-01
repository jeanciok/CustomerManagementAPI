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

            CustomerViewModel customerViewModel = new(customer.Tenant, customer.Name, customer.BirthDate, customer.PhoneNumber, customer.BusinessPhone, customer.HomePhone, customer.CNPJ, 
                customer.CPF, customer.RG, customer.CEP, customer.Street, customer.Number, customer.Additional, customer.Group, customer.Email, customer.Site, customer.Description, 
                customer.URLPicture, customer.City, customer.CreatedAt, customer.UpdatedAt, customer.Attachments);

            return customerViewModel;
        }
    }
}
