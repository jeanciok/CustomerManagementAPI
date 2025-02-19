using MediatR;

namespace CustomerManagement.Application.Queries.GetPreSignedUrl
{
    public class GetPreSignedUrlQuery : IRequest<string>
    {
        public GetPreSignedUrlQuery(Guid attachmentId)
        {
            AttachmentId = attachmentId;
        }

        public Guid AttachmentId { get; private set; }
    }
}
