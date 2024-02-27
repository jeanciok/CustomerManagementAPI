using CustomerManagement.Application.Commands.CreateTenant;
using CustomerManagement.Application.Queries.GetTenantById;
using CustomerManagement.Application.Queries.GetUserById;
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
            Guid tenantId = await _mediator.Send(command);

            return Created("", tenantId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetTenantByIdQuery query = new(id);

            TenantViewModel viewModel = await _mediator.Send(query);

            return Ok(viewModel);
        }
    }
}