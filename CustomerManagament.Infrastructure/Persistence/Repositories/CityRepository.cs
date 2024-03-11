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
    public class CityRepository : ICityRepository
    {
        private readonly CustomerManagementDbContext _dbContext;

        public CityRepository(CustomerManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<City>> Get()
        {
            return await _dbContext.City
                .Include(c => c.State)
                .ToListAsync();
        }

        public Task<City> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetByUf(string uf)
        {
            return await _dbContext.City
                .FirstOrDefaultAsync(c => c.State.Uf == uf);
        }
    }
}
