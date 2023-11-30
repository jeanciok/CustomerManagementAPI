using CustomerManagement.Application.Commands.DeleteCustomerGroup;
using CustomerManagement.Application.Commands.DeleteUser;
using CustomerManagement.Application.Commands.UpdateCustomerGroup;
using CustomerManagement.Application.Queries.GetAllCustomerGroups;
using CustomerManagement.Application.Queries.GetCustomerGroupById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCustomerGroupsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCustomerGroupByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCustomerGroupCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            DeleteCustomerGroupCommand command = new(id);

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
