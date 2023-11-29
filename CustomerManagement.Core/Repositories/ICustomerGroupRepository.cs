using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace CustomerManagement.Core.Repositories
{
    public interface ICustomerGroupRepository
    {
        Task<List<CustomerGroup>> GetAllAsync();
        Task<CustomerGroup> GetByIdAsync(Guid id);
        Task AddAsync(CustomerGroup customerGroup);
        Task UpdateAsync(CustomerGroup customerGroup);
        Task DeleteAsync(Guid id);
    }
}
