using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
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

        public AttachmentRepository(CustomerManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Attachment attachment)
        {
            await _context.AddAsync(attachment);
            await _context.SaveChangesAsync();
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
