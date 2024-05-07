using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.DeleteAttachment
{
    public class DeleteAttachmentCommandHandler : IRequestHandler<DeleteAttachmentCommand, Unit>
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IAttachmentRepository _attachmentRepository;

        public DeleteAttachmentCommandHandler(IFileStorageService fileStorageService, IAttachmentRepository attachmentRepository)
        {
            _fileStorageService = fileStorageService;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Unit> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(request.Id);

            await _fileStorageService.DeleteFileAsync(attachment.FileUrl);

            await _attachmentRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
