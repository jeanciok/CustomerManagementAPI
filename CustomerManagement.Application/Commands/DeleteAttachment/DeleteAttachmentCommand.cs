using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.DeleteAttachment
{
    public class DeleteAttachmentCommand : IRequest<Unit>
    {
        public DeleteAttachmentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
