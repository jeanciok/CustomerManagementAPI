using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagament.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Guid tempTenant = Guid.Parse("f3680a57-795e-4ef7-9e10-cf54d2b6c42f");

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
