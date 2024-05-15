using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagament.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Guid tempTenant = Guid.Parse("644d1f61-575b-444f-858f-5471a0b4f3d4");
        private Guid tempRole = Guid.Parse("62d8acf1-1577-4d1a-b6ba-62e214e0fe8b");

        private readonly CustomerManagementDbContext _dbContext;

        public UserRepository(CustomerManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);

            if (user is not null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users
                   .Include(u => u.Role)
                   .Include(u => u.Tenant)
                   .Where(u => u.TenantId == tempTenant)
                   .ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users
                .Include(u => u.Role)
                .Include(u => u.Tenant)
                .Where(u => u.TenantId == tempTenant && u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            user.TenantId = tempTenant;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAndPasswordHash(string email, string passwordHash)
        {
            return await _dbContext.Users
                .Include(u => u.Tenant)
                .Include(u => u.Role)
                .Where(u => u.Email == email && u.Password == passwordHash)
                .SingleOrDefaultAsync();
        }
    }
}
