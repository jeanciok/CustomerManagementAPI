using CustomerManagement.Application.Queries.GetCityByUf;
using CustomerManagement.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "tenant_admin, tenant_user")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("byUf/{uf}")]
        public async Task<IActionResult> GetByUf(string uf)
        {
            GetCityByUfQuery query = new GetCityByUfQuery(uf);

            List<CityViewModel> cities = await _mediator.Send(query);

            return Ok(cities);
        }
    }
}
