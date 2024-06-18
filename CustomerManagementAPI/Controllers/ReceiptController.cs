using CustomerManagement.Application.Commands.CreateReceipt;
using CustomerManagement.Application.Commands.DeleteReceipt;
using CustomerManagement.Application.Commands.UpdateReceipt;
using CustomerManagement.Application.Queries.GetAllReceipts;
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int number, [FromQuery] string customerName)
        {
            var query = new GetReceiptsQuery(number, customerName);
            var receipts = await _mediator.Send(query);
            return Ok(receipts);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReceiptCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateReceiptCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteReceiptCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
