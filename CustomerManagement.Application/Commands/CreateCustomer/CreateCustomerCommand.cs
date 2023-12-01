using MediatR;
using System;

namespace CustomerManagement.Application.Commands.AddCustomer
{
    public class CreateCustomerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CreateCustomerCommand(Guid id, string name /*, other properties*/)
        {
            Id = id;
            Name = name;
        }
    }
}
