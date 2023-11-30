using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.Persistence.Repositories
{
    public class CustomerGroupRepository : ICustomerGroupRepository
    {
        private Guid tempTenant = Guid.Parse("f3680a57-795e-4ef7-9e10-cf54d2b6c42f");

        private readonly CostumerManagementDbContext _dbContext;

        public CustomerGroupRepository(CostumerManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(CustomerGroup customerGroup)
        {
            customerGroup.TenantId = tempTenant;
            await _dbContext.CustomerGroups.AddAsync(customerGroup);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customerGroup = await GetByIdAsync(id);

            if (customerGroup is not null)
            {
                _dbContext.CustomerGroups.Remove(customerGroup);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CustomerGroup>> GetAllAsync()
        {
            return await _dbContext.CustomerGroups
                .Where(cg => cg.TenantId == tempTenant)
                .Include(cg => cg.Customers)
                .ToListAsync();
        }

        public async Task<CustomerGroup> GetByIdAsync(Guid id)
        {
            return await _dbContext.CustomerGroups
                .Where(cg => cg.TenantId == tempTenant && cg.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(CustomerGroup customerGroup)
        {
            customerGroup.TenantId = tempTenant;
            _dbContext.CustomerGroups.Update(customerGroup);
            await _dbContext.SaveChangesAsync();
        }
    }
}
