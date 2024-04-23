using CustomerManagement.Application.Queries.GetAllAttachments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
    }
}
