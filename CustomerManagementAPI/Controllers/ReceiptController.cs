using CustomerManagement.Application.Commands.CreateReceipt;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "tenant_admin, tenant_user")]
    public class ReceiptController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReceiptController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] int number, [FromQuery] string customerName)
        //{
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReceiptCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
