using MediatR;
using System;

namespace CustomerManagement.Application.Commands.DeleteCustomerGroup
{
    public class DeleteCustomerGroupCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteCustomerGroupCommand(Guid id)
        {
            Id = id;
        }
    }
}
