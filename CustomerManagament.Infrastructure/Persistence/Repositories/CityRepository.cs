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

        public async Task<List<City>> GetAll()
        {
            return await _dbContext.City
                .Include(c => c.State)
                .ToListAsync();
        }

        public async Task<List<City>> GetAllByUf(string uf)
        {
            return await _dbContext.City
                .Include(c => c.State)
                .Where(c => c.State.Uf == uf)
                .ToListAsync();
        }

        public async Task<City> GetByIbge(int ibge)
        {
            return await _dbContext.City
                .Include(c => c.State)
                .Where(c => c.Ibge == ibge)
                .SingleOrDefaultAsync();
        }
    }
}
