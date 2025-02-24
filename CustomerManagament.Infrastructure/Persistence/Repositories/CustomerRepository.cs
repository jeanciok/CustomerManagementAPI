using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CustomerManagament.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using CustomerManagement.Core.Helpers;

namespace CustomerManagement.Core.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerManagementDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Guid _tenantId;
        private readonly Guid _userId;

        public CustomerRepository(CustomerManagementDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;

            _httpContextAccessor = httpContextAccessor;
            var _userClaims = _httpContextAccessor.HttpContext.User.Claims;
            _tenantId = Guid.Parse(_userClaims.FirstOrDefault(c => c.Type == "tenant_id").Value);
            _userId = Guid.Parse(_userClaims.FirstOrDefault(c => c.Type == "id").Value);
        }

        public async Task AddAsync(Customer customer)
        {
            customer.TenantId = _tenantId;
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(List<Customer>, int)> Get(string name, string cpfCnpj, int page, int pageSize)
        {
            IQueryable<Customer> query = _context.Customers
                .Where(c => c.TenantId == _tenantId)
                .Include(c => c.City)
                .Include(c => c.City.State);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }

            if (!string.IsNullOrEmpty(cpfCnpj) && cpfCnpj.IsCpf())
            {
                query = query.Where(c => c.Cpf == cpfCnpj);
            }

            if (!string.IsNullOrEmpty(cpfCnpj) && cpfCnpj.IsCnpj())
            {
                query = query.Where(c => c.Cnpj == cpfCnpj);
            }

            int total = await query.CountAsync();

            var customers = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (customers, total);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Customers
                .Where(c => c.TenantId == _tenantId)
                .Include(c => c.City)
                .Include(c => c.City.State)
                .Include(c => c.Attachments)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task UpdateAsync(Customer customer)
        {
            customer.TenantId = _tenantId;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
