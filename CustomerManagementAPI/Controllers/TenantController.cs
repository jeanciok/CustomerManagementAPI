using CustomerManagement.Application.Commands.CreateTenant;
using CustomerManagement.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTenantCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}