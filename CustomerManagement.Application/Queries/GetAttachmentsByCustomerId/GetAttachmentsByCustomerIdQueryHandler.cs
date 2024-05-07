using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetAllAttachments
{
    public class GetAttachmentsByCustomerIdQueryHandler : IRequestHandler<GetAttachmentsByCustomerIdQuery, List<AttachmentViewModel>>
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly string _bucketURL;

        public GetAttachmentsByCustomerIdQueryHandler(IAttachmentRepository attachmentRepository, IConfiguration configuration)
        {
            _attachmentRepository = attachmentRepository;
            _bucketURL = configuration["Storage:BucketURL"];
        }

        public async Task<List<AttachmentViewModel>> Handle(GetAttachmentsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            List<Attachment> attachments = await _attachmentRepository.GetByCustomerIdAsync(request.CustomerId);

            List<AttachmentViewModel> attachmentViewModels = attachments
                .Select(a => new AttachmentViewModel(a.Id, a.Name, $"{_bucketURL}/{a.FileUrl}", a.FileType, a.CreatedAt))
                .ToList();

            return attachmentViewModels;
        }
    }
}
