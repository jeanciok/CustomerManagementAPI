using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CustomerManagament.Infrastructure.Persistence;

namespace CustomerManagement.Core.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerManagementDbContext _context;

        public CustomerRepository(CustomerManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
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

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
