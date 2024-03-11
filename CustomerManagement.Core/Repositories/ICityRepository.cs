using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> Get();
        Task<City> GetById(Guid id);
        Task<City> GetByUf(string uf);
    }
}
