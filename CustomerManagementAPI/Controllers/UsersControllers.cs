using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Application.Queries.GetAllUsers;
using CustomerManagement.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/users")]
    public class UsersControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllUsersQuery query = new();

            List<UserViewModel> users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            Guid userId = await _mediator.Send(command);

            return Ok(userId);
        }
    }
}
