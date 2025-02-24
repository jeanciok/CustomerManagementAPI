using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Helpers;
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
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            customer.Name = request.Name;
            customer.PhoneNumber = request.PhoneNumber;
            customer.PhoneNumber2 = request.PhoneNumber2;
            customer.Cnpj = request.CNPJ.IsCnpj() ? request.CNPJ : string.Empty;
            customer.Cpf = request.CPF.IsCpf() ? request.CPF : string.Empty;
            customer.Cep = request.CEP;
            customer.Street = request.Street;
            customer.Number = request.Number;
            customer.District = request.District;
            customer.Additional = request.Additional;
            customer.Email = request.Email;
            customer.Description = request.Description;
            customer.CityId = request.CityId;
            customer.UpdatedAt = DateTime.Now;

            await _customerRepository.UpdateAsync(customer);
            return Unit.Value;
        }
    }
}
