using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.CreateCustomerGroup
{
    public class CreateCustomerGroupCommandHandler : IRequestHandler<CreateCustomerGroupCommand, Guid>
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;

        public CreateCustomerGroupCommandHandler(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        public async Task<Guid> Handle(CreateCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            var customerGroup = new CustomerGroup(Guid.NewGuid(), request.Name);
            await _customerGroupRepository.AddAsync(customerGroup);

            return customerGroup.Id;
        }
    }
}
