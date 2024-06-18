using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Repositories
{
    public interface IReceiptRepository
    {
        Task AddAsync(Receipt receipt);
        Task DeleteAsync(Guid id);
        Task<List<Receipt>> Get(int number, string customerName);
        Task<Receipt> GetByIdAsync(Guid id);
        Task UpdateAsync(Receipt receipt);
    }
}
