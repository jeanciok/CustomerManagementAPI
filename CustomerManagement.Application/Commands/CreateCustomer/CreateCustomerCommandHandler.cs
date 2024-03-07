using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.AddCustomer
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
            var customer = new Customer(Guid.NewGuid(), request.Name, request.PhoneNumber, request.CNPJ, request.CPF, request.RG, request.CEP,
                request.Street, request.Number, request.Additional, request.Email, request.Site, request.Description, request.URLPicture, request.CityId, request.GroupId);

            await _customerRepository.AddAsync(customer);
            return customer.Id;
        }
    }
}
