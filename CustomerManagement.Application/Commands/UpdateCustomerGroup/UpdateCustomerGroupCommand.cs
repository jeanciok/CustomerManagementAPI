using MediatR;
using System;

namespace CustomerManagement.Application.Commands.UpdateCustomerGroup
{
    public class UpdateCustomerGroupCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UpdateCustomerGroupCommand(Guid id, string name, string tenant)
        {
            Id = id;
            Name = name;
        }
    }
}
