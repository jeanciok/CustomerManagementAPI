using CustomerManagement.Application.Commands.AddCustomer;
using CustomerManagement.Application.Commands.DeleteCustomer;
using CustomerManagement.Application.Commands.UpdateAvatarCustomer;
using CustomerManagement.Application.Commands.UpdateCustomer;
using CustomerManagement.Application.Queries.GetAllCustomers;
using CustomerManagement.Application.Queries.GetCustomerById;
using CustomerManagement.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFileStorageService _fileStorageService;

        public CustomerController(IMediator mediator, IFileStorageService fileStorageService)
        {
            _mediator = mediator;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? name, [FromQuery] string? cpf, [FromQuery] string? cnpj)
        {
            var query = new GetAllCustomersQuery
            {
                Name = name,
                Cpf = cpf,
                Cnpj = cnpj
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCustomerCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("updateAvatar/{customerId}")]
        public async Task<IActionResult> UpdateAvatar(IFormFile avatar, Guid customerId)
        {
            UpdateCustomerAvatarCommand command = new(avatar, customerId);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
