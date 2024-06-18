using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(Guid.NewGuid(), request.Name, request.PhoneNumber, request.PhoneNumber2, request.Cnpj, request.Cpf, request.Rg, request.Cep,
                request.Street, request.Number, request.District, request.Additional, request.Email, request.Description, request.CityId, request.GroupId);

            await _customerRepository.AddAsync(customer);
            return customer.Id;
        }
    }
}
