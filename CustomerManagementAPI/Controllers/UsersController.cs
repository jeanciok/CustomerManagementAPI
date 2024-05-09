using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Application.Commands.DeleteUser;
using CustomerManagement.Application.Commands.LoginUser;
using CustomerManagement.Application.Commands.UpdateUser;
using CustomerManagement.Application.Queries.GetAllUsers;
using CustomerManagement.Application.Queries.GetUserById;
using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Services;
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
        private readonly IAuthService _authService;
        private readonly IFileStorageService _fileStorageService;

        public UsersController(IMediator mediator, IAuthService authService, IFileStorageService fileStorageService)
        {
            _mediator = mediator;
            _authService = authService;
            _fileStorageService = fileStorageService;
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
            GetUserByIdQuery query = new(id);

            UserViewModel user = await _mediator.Send(query);

            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost]
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

            Guid userId = await _mediator.Send(command);

            // TODO: Change this to return a 201 Created response
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

        [AllowAnonymous]
        [HttpGet("validateToken")]
        public IActionResult ValidateToken([FromQuery] string token)
        {
            bool isValid = _authService.IsTokenValid(token);

            return Ok(isValid);
        }

        // TODO: This controller is for testing digitalocean storage, after testing they will be deleted
        //[AllowAnonymous]
        //[HttpPost("uploadAvatar")]
        //public IActionResult UploadAvatar(IFormFile file)
        //{
        //    _fileStorageService.UploadFiles(file, "profile_avatar");
        //    return NoContent();
        //}
    }
}