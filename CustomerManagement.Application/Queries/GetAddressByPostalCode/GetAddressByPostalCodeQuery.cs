using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using MediatR;

namespace CustomerManagement.Application.Queries.GetAddressByPostalCode
{
    public class GetAddressByPostalCodeQuery : IRequest<AddressViewModel>
    {
        public string PostalCode { get; }

        public GetAddressByPostalCodeQuery(string postalCode)
        {
            PostalCode = postalCode;
        }
    }
}
