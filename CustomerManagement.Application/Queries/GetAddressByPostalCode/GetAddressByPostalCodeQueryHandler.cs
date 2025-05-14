using CustomerManagement.Application.Services;
using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Exceptions;
using MediatR;


namespace CustomerManagement.Application.Queries.GetAddressByPostalCode
{


    public class GetAddressByPostalCodeQueryHandler : IRequestHandler<GetAddressByPostalCodeQuery, AddressViewModel>
    {
        private readonly IOpenCepService _openCepService;

        public GetAddressByPostalCodeQueryHandler(IOpenCepService openCepService)
        {
            _openCepService = openCepService;
        }

        public async Task<AddressViewModel> Handle(GetAddressByPostalCodeQuery request, CancellationToken cancellationToken)
        {
            var address = await _openCepService.GetAddressByPostalCode(request.PostalCode);

            var addressViewModel = new AddressViewModel
            {
                PostalCode = address.PostalCode,
                Street = address.Street,
                District = address.District,
                City = new CityViewModel(address.City.Id, address.City.Name, address.City.State.Uf)
            };

            return addressViewModel;
        }
    }
}
