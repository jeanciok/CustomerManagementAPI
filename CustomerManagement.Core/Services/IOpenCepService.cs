using CustomerManagement.Core.Entities;

namespace CustomerManagement.Application.Services
{
    public interface IOpenCepService
    {
        Task<Address> GetAddressByPostalCode(string postalCode);
    }
}
