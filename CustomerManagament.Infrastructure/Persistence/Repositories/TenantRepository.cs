using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagament.Infrastructure.Persistence;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly CustomerManagementDbContext _context;

        public TenantRepository(CustomerManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant> GetByIdAsync(Guid id)
        {
            return await _context.Tenants
                .FirstOrDefaultAsync(c => c.TenantId == id);
        }

        public async Task<List<Tenant>> GetAllAsync()
        {
            return await _context.Tenants
                .ToListAsync();
        }

        public async Task AddAsync(Tenant tenant)
        {
            await _context.AddAsync(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tenant tenant)
        {
            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();
        }
    }
}