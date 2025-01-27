using CustomerManagement.Application.Commands.CreateTenant;
using CustomerManagement.Application.Queries.GetTenantById;
using CustomerManagement.Application.ViewModels;
using CustomerManagementAPI.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TenantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [IgnoreTenant]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateTenantCommand command)
        {
            Guid tenantId = await _mediator.Send(command);

            return Created("", tenantId);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetTenantByIdQuery query = new(id);

            TenantViewModel viewModel = await _mediator.Send(query);

            return Ok(viewModel);
        }
    }
}