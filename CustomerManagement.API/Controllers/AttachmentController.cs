using CustomerManagement.Application.Commands.DeleteAttachment;
using CustomerManagement.Application.Commands.UploadAttachment;
using CustomerManagement.Application.Queries.GetAllAttachments;
using CustomerManagement.Application.Queries.GetPreSignedUrl;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "tenant_admin, tenant_user")]
    public class AttachmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttachmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomerId(Guid customerId)
        {
            GetAttachmentsByCustomerIdQuery query = new(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("{customerId}")]
        public async Task<IActionResult> Upload(List<IFormFile> files, Guid customerId)
        {
            UploadAttachmentCommand command = new(customerId, files);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteAttachmentCommand command = new(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        [Route("presigned-url/{attachmentId}")]
        public async Task<IActionResult> GetPreSignedUrl(Guid attachmentId)
        {
            GetPreSignedUrlQuery query = new(attachmentId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
