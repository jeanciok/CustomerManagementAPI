using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.CreateCustomerGroup
{
    public class CreateCustomerGroupCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
