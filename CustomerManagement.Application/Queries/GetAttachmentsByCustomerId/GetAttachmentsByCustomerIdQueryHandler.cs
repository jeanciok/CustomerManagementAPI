using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
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

        public GetAttachmentsByCustomerIdQueryHandler(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<List<AttachmentViewModel>> Handle(GetAttachmentsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            List<Attachment> attachments = await _attachmentRepository.GetByCustomerIdAsync(request.CustomerId);

            List<AttachmentViewModel> attachmentViewModels = attachments
                .Select(a => new AttachmentViewModel(a.Id, a.Name, a.FileUrl))
                .ToList();

            return attachmentViewModels;
        }
    }
}
