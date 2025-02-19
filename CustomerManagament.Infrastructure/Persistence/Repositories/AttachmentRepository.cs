using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.Persistence.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly CustomerManagementDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Guid _tenantId;

        public AttachmentRepository(CustomerManagementDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            var _userClaims = _httpContextAccessor.HttpContext.User.Claims;
            _tenantId = Guid.Parse(_userClaims.FirstOrDefault(c => c.Type == "tenant_id").Value);
        }

        public async Task AddAsync(Attachment attachment)
        {
            await _context.AddAsync(attachment);
            await _context.SaveChangesAsync();
        }

        public async Task<Attachment> GetByIdAsync(Guid id)
        {
            return await _context.Attachments
                .Where(a => a.Customer.TenantId.Equals(_tenantId))
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var attachment = await _context.Attachments.FindAsync(id);
            if (attachment != null)
            {
                _context.Attachments.Remove(attachment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Attachment>> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.Attachments
                .Where(a => a.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
