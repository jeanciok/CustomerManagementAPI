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
    public class StateRepository : IStateRepository
    {
        private readonly CustomerManagementDbContext _dbContext;
        public StateRepository(CustomerManagementDbContext dbContext)

        {
            _dbContext = dbContext;
        }

        public async Task<List<State>> GetAll()
        {
            List<State> states = await _dbContext.State
                .OrderBy(x => x.Name)
                .ToListAsync();

            return states;
        }
    }
}
