using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UploadAttachment
{
    public class UploadAttachmentCommand : IRequest<Unit>
    {
        public UploadAttachmentCommand(Guid customerId, List<IFormFile> files)
        {
            CustomerId = customerId;
            Files = files;
        }

        public Guid CustomerId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
