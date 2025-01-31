using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CustomerManagament.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CustomerManagementDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Guid _tenantId;

        public UserRepository(CustomerManagementDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;

            var _userClaims = _httpContextAccessor.HttpContext?.User.Claims;
            var tenantIdClaim = _userClaims?.FirstOrDefault(c => c.Type == "tenant_id")?.Value;

            if (!string.IsNullOrEmpty(tenantIdClaim))
            {
                _tenantId = Guid.Parse(tenantIdClaim);
            }
            else
            {
                _tenantId = Guid.Empty;
            }
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
                   .Include(u => u.Tenant)
                   .Where(u => u.TenantId == _tenantId)
                   .ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            IQueryable<User> query = _dbContext.Users
                .Include(u => u.Tenant)
                .Where(u => u.Id == id);

            if (_tenantId != Guid.Empty)
            {
                query = query.Where(u => u.TenantId == _tenantId);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAndPasswordHashAsync(string email, string passwordHash)
        {
            return await _dbContext.Users
                .Include(u => u.Tenant)
                .Where(u => u.Email == email && u.Password == passwordHash)
                .SingleOrDefaultAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
                //.Include(u => u.Tenant)
                .Where(u => u.Email == email)
                .SingleOrDefaultAsync();
        }

        public async Task<User> GetByPasswordResetTokenAsync(string token)
        {
            return await _dbContext.Users
                //.Include(u => u.Tenant)
                .Where(u => u.PasswordResetToken == token)
                .SingleOrDefaultAsync();
        }
    }
}
