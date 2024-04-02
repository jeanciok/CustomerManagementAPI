using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.DeleteCustomerAvatar
{
    public class DeleteCustomerAvatarCommand : IRequest<Unit>
    {
        public DeleteCustomerAvatarCommand(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; set; }
    }
}
