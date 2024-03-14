using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Id, request.Name, request.PhoneNumber, request.PhoneNumber2, request.CNPJ, request.CPF, request.RG, request.CEP,
                               request.Street, request.Number, request.District, request.Additional, request.Email, request.Description, request.CityId, request.GroupId);

            await _customerRepository.UpdateAsync(customer);
            return Unit.Value;
        }
    }
}
