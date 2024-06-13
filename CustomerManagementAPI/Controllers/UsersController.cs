using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Application.Commands.DeleteUser;
using CustomerManagement.Application.Commands.LoginUser;
using CustomerManagement.Application.Commands.UpdateUser;
using CustomerManagement.Application.Commands.UpdateUserAvatar;
using CustomerManagement.Application.Queries.GetAllUsers;
using CustomerManagement.Application.Queries.GetUserById;
using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;
        private readonly IFileStorageService _fileStorageService;

        public UsersController(IMediator mediator, IAuthService authService, IFileStorageService fileStorageService)
        {
            _mediator = mediator;
            _authService = authService;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        [Authorize(Roles = "tenant_admin")]
        public async Task<IActionResult> Get()
        {
            GetAllUsersQuery query = new();

            List<UserViewModel> users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "tenant_admin, tenant_user")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetUserByIdQuery query = new(id);

            UserViewModel user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            Guid userId = Guid.Parse(User.FindFirst("id").Value);

            GetUserByIdQuery query = new(userId);

            UserViewModel user = await _mediator.Send(query);

            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "tenant_admin")]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            //if (!ModelState.IsValid)
            //{
            //    var messages = ModelState
            //        .SelectMany(msg => msg.Value.Errors)
            //        .Select(e => e.ErrorMessage)
            //        .ToList();

            //    return BadRequest(messages);
            //}

            Guid tenantId = Guid.Parse(User.FindFirst("tenant_id").Value);

            command.TenantId = tenantId;

            Guid userId = await _mediator.Send(command);

            // TODO: Change this to return a 201 Created response
            return Ok(userId);
        }

        [HttpPut]
        [Authorize(Roles = "tenant_admin, tenant_user")]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "tenant_admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteUserCommand deleteUserCommand = new(id);

            await _mediator.Send(deleteUserCommand);

            return NoContent();
        }

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

        [HttpPut("updateAvatar/{userId}")]
        [Authorize(Roles = "tenant_admin, tenant_user")]
        public async Task<IActionResult> UpdateAvatar(List<IFormFile> avatar, Guid userId)
        {
            UpdateUserAvatarCommand command = new(avatar, userId);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}