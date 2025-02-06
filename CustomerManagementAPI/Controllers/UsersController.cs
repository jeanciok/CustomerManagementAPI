using CustomerManagement.Application.Commands.ChangePassword;
using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Application.Commands.DeleteUser;
using CustomerManagement.Application.Commands.LoginUser;
using CustomerManagement.Application.Commands.UpdateUser;
using CustomerManagement.Application.Commands.UpdateUserAvatar;
using CustomerManagement.Application.Queries.GetAllUsers;
using CustomerManagement.Application.Queries.GetUserById;
using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Services;
using CustomerManagementAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using CustomerManagementAPI.Attributes;
using CustomerManagement.Application.Commands.ForgotPassword;
using CustomerManagement.Application.Commands.ResetPassword;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IEmailService _emailService;

        public UsersController(IMediator mediator, IAuthService authService, IFileStorageService fileStorageService, IEmailService emailService)
        {
            _mediator = mediator;
            _authService = authService;
            _fileStorageService = fileStorageService;
            _emailService = emailService;
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

        [IgnoreTenant]
        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            LoginUserViewModel response = await _mediator.Send(command);

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

        [HttpPut("changePassword")]
        [Authorize(Roles = "tenant_admin, tenant_user")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            Guid userId = Guid.Parse(User.FindFirst("id").Value);

            command.UserId = userId;

            await _mediator.Send(command);

            return NoContent();
        }

        [IgnoreTenant]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [IgnoreTenant]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}