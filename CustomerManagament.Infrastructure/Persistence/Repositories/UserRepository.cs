﻿using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagament.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Guid tempTenant = Guid.Parse("f3680a57-795e-4ef7-9e10-cf54d2b6c42f");
        private Guid tempRole = Guid.Parse("62d8acf1-1577-4d1a-b6ba-62e214e0fe8b");

        private readonly CostumerManagementDbContext _dbContext;

        public UserRepository(CostumerManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            // Remove as soon as you finish configuring the tenant
            user.TenantId = tempTenant;
            user.RoleId = tempRole;
            //

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users
                   .Include(u => u.Role)
                   .Where(u => u.TenantId == tempTenant)
                   .ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users
                .Include(u => u.Role)
                .Where(u => u.TenantId == tempTenant && u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
