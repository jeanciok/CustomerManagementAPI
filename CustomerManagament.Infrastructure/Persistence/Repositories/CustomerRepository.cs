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

        private Guid tempTenant = Guid.Parse("644d1f61-575b-444f-858f-5471a0b4f3d4");

        public CustomerRepository(CustomerManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            customer.TenantId = tempTenant;
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

        public async Task<List<Customer>> Get(string name, string cpf, string cnpj)
        {
            // TODO - Include Group
            IQueryable<Customer> query = _context.Customers
                .Include(c => c.City)
                .Include(c => c.City.State)
                .Include(g => g.Group);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(c => c.Equals(cpf));
            }

            if (!string.IsNullOrEmpty(cnpj))
            {
                query = query.Where(c => c.Equals(cnpj));
            }

            return await query.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            // TODO - Include Group

            return await _context.Customers
                .Include(c => c.City)
                //.Include(c => c.Group)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            customer.TenantId = tempTenant;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
