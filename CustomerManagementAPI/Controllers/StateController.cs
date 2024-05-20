using CustomerManagement.Application.Queries.GetAllStates;
using CustomerManagement.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "tenant_admin, tenant_user")]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllStatesQuery query = new();

            List<StateViewModel> states = await _mediator.Send(query);

            return Ok(states);
        }

    }
}
