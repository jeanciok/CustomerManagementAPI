using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.DeleteCustomerGroup
{
    public class DeleteCustomerGroupCommandHandler : IRequestHandler<DeleteCustomerGroupCommand, Unit>
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;

        public DeleteCustomerGroupCommandHandler(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            await _customerGroupRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
