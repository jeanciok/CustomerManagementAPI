using CustomerManagement.Core.Entities;

namespace CustomerManagement.Core.Repositories
{
    public interface IAttachmentRepository
    {
        Task AddAsync(Attachment attachment);
        Task<Attachment> GetByIdAsync(Guid id);
        Task<List<Attachment>> GetByCustomerIdAsync(Guid customerId);
        Task DeleteAsync(Guid id);
    }
}
