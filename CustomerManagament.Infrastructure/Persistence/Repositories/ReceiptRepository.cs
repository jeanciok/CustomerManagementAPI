using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagament.Infrastructure.Persistence.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly CustomerManagementDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Guid _tenantId;
        private readonly Guid _userId;

        public ReceiptRepository(IHttpContextAccessor httpContextAccessor, CustomerManagementDbContext context)
        {
            _context = context;

            _httpContextAccessor = httpContextAccessor;
            var _userClaims = _httpContextAccessor.HttpContext.User.Claims;
            _tenantId = Guid.Parse(_userClaims.FirstOrDefault(c => c.Type == "tenant_id").Value);
            _userId = Guid.Parse(_userClaims.FirstOrDefault(c => c.Type == "id").Value);
        }

        public async Task AddAsync(Receipt receipt)
        {
            receipt.TenantId = _tenantId;
            receipt.CreatedBy = _userId;

            int lastReceiptNumber = await _context.Receipts
                .Where(r => r.TenantId.Equals(_tenantId))
                .OrderByDescending(r => r.Number)
                .Select(r => r.Number)
                .FirstOrDefaultAsync();

            receipt.Number = lastReceiptNumber + 1;

            await _context.AddAsync(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt != null)
            {
                _context.Receipts.Remove(receipt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Receipt>> Get(int number, string customerName)
        {
            IQueryable<Receipt> query = _context.Receipts
                .Where(r => r.TenantId.Equals(_tenantId))
                .Include(r => r.Customer)
                .Include(r => r.Tenant)
                .Include(r => r.User);

            if (number > 0)
            {
                query = query.Where(r => r.Number.Equals(number));
            }

            if (!string.IsNullOrEmpty(customerName))
            {
                query = query.Where(r => r.Customer.Name.Contains(customerName));
            }

            return await query.ToListAsync();
        }

        public async Task<Receipt> GetByIdAsync(Guid id)
        {
            return await _context.Receipts
                .Where(r => r.TenantId.Equals(_tenantId))
                .Include(r => r.Customer)
                .Include(r => r.Customer.City)
                .Include(r => r.Tenant)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id.Equals(id));
        }

        public async Task UpdateAsync(Receipt receipt)
        {
            receipt.TenantId = _tenantId;
            _context.Receipts.Update(receipt);
            await _context.SaveChangesAsync();
        }
    }
}
