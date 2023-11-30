using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UpdateCustomerGroup
{
    public class UpdateCustomerGroupCommandHandler : IRequestHandler<UpdateCustomerGroupCommand, Unit>
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;

        public UpdateCustomerGroupCommandHandler(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            var customerGroup = new CustomerGroup
            {
                Id = request.Id,
                Name = request.Name,
            };

            await _customerGroupRepository.UpdateAsync(customerGroup);
            return Unit.Value;
        }
    }
}
