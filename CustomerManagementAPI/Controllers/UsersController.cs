﻿using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Application.Commands.DeleteUser;
using CustomerManagement.Application.Commands.LoginUser;
using CustomerManagement.Application.Commands.UpdateUser;
using CustomerManagement.Application.Queries.GetAllUsers;
using CustomerManagement.Application.Queries.GetUserById;
using CustomerManagement.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetUserByIdQuery query = new GetUserByIdQuery(id);

            UserViewModel user = await _mediator.Send(query);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            Guid userId = await _mediator.Send(command);

            return Ok(userId);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteUserCommand deleteUserCommand = new(id);

            await _mediator.Send(deleteUserCommand);

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            LoginUserViewModel response = await _mediator.Send(command);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}
