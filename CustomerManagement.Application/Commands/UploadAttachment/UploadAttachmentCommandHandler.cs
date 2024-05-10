using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UploadAttachment
{
    public class UploadAttachmentCommandHandler : IRequestHandler<UploadAttachmentCommand, Unit>
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IAttachmentRepository _attachmentRepository;

        public UploadAttachmentCommandHandler(IFileStorageService fileStorageService, IAttachmentRepository attachmentRepository)
        {
            _fileStorageService = fileStorageService;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Unit> Handle(UploadAttachmentCommand request, CancellationToken cancellationToken)
        {
            Dictionary<string, IFormFile> uploadFiles = _fileStorageService.UploadFiles(request.Files, "attachments");

            foreach (var item in uploadFiles)
            {
                var attachment = new Attachment(item.Value.FileName, item.Key, MimeTypes.GetMimeTypeExtensions(item.Value.ContentType).First(), request.CustomerId);
                await _attachmentRepository.AddAsync(attachment);
            }

            return Unit.Value;
        }
    }
}
