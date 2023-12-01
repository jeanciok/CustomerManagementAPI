using MediatR;
using System;

namespace CustomerManagement.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Add other properties as needed

        public UpdateCustomerCommand(Guid id, string name /*, other properties*/)
        {
            Id = id;
            Name = name;
            // Assign other properties
        }
    }
}
