using CustomerManagement.Application.Commands.CreateReceipt;
using CustomerManagement.Application.Commands.DeleteReceipt;
using CustomerManagement.Application.Commands.UpdateReceipt;
using CustomerManagement.Application.Queries.GenerateReceiptPdf;
using CustomerManagement.Application.Queries.GetAllReceipts;
using CustomerManagement.Application.Queries.GetReceiptById;
using CustomerManagement.Application.ViewModels;
using CustomerManagementAPI.Filters;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReceiptController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] int number,
            [FromQuery] string customerName,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetReceiptsQuery
            {
                Number = number,
                CustomerName = customerName,
                StartDate = startDate,
                EndDate = endDate,
                Page = page,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetReceiptByIdQuery(id);
            var receipt = await _mediator.Send(query);
            return Ok(receipt);
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

        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> GetReceiptPdf(Guid id)
        {
            var query = new GenerateReceiptPdfQuery(id);
            PdfViewModel pdf = await _mediator.Send(query);

            Response.Headers.Add("Content-Disposition", $"attachment; filename={pdf.FileName}.pdf");
            return File(pdf.File, "application/pdf");
        }
    }
}
