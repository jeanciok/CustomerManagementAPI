using CustomerManagement.Application.Queries.GetAddressByPostalCode;
using CustomerManagement.Application.ViewModels;
using CustomerManagementAPI.Attributes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [IgnoreTenant]
        [HttpGet("byPostalCode/{postalCode}")]
        public async Task<IActionResult> GetByPostalCode(string postalCode)
        {
            GetAddressByPostalCodeQuery query = new GetAddressByPostalCodeQuery(postalCode);
            AddressViewModel address = await _mediator.Send(query);
            return Ok(address);
        }
    }
}
