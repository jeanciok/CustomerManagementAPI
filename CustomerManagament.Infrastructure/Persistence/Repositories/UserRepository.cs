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
    public class UserRepository : IUserRepository
    {
        private Guid tempGuid = Guid.Parse("bbda7fc7-f064-4b89-8cb0-ddd6d8109999");

        private readonly CostumerManagementDbContext _dbContext;

        public UserRepository(CostumerManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _dbContext.Users
                   .Include(u => u.Role)
                   .Where(u => u.TenantId == tempGuid)
                   .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users
                .Include(u => u.Role)
                .Where(u => u.TenantId == tempGuid && u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
