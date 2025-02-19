using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;

namespace CustomerManagement.Application.Queries.GetPreSignedUrl
{
    public class GetPreSignedUrlQueryHandler : IRequestHandler<GetPreSignedUrlQuery, string>
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IAttachmentRepository _attachmentRepository;

        public GetPreSignedUrlQueryHandler(IFileStorageService fileStorageService, IAttachmentRepository attachmentRepository)
        {
            _fileStorageService = fileStorageService;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<string> Handle(GetPreSignedUrlQuery request, CancellationToken cancellationToken)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(request.AttachmentId);

            string url = _fileStorageService.GeneratePreSignedUrl(attachment.FileUrl, 60);
            
            return url;
        }
    }
}
