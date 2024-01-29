using CustomerManagement.Core.Entities;

namespace CustomerManagement.Core.Interfaces
{
    public interface ITenantRepository
    {
        Task<Tenant> GetByIdAsync(Guid id);
        Task<List<Tenant>> GetAllAsync();
        Task AddAsync(Tenant tenant);
        Task UpdateAsync(Tenant tenant);
    }
}