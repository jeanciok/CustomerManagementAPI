using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerViewModel>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerViewModel>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customers = await _customerRepository.Get(request.Name, request.Cpf, request.Cnpj);

            List<CustomerViewModel> customerViewModels = customers
                .Select(c => new CustomerViewModel(c.Id, c.Name, c.PhoneNumber, c.PhoneNumber2, c.Cnpj,
                    c.Cpf, c.Rg, c.Cep, c.Street, c.Number, c.District, c.Additional, c.Email, c.Description,
                    c.City, c.CreatedAt, c.UpdatedAt, new CustomerGroupViewModel(c.Group.Id, c.Group.Name), c.AvatarUrl))
                .ToList();

            return customerViewModels;
        }
    }
}
