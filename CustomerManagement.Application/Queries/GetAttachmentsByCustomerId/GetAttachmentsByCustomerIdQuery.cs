using CustomerManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetAllAttachments
{
    public class GetAttachmentsByCustomerIdQuery : IRequest<List<AttachmentViewModel>>
    {
        public Guid CustomerId { get; set; }

        public GetAttachmentsByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
