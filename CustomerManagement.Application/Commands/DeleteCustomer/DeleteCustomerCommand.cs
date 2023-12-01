﻿using MediatR;
using System;

namespace CustomerManagement.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}
