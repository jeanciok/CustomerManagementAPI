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
        Task<List<City>> GetAll();
        Task<List<City>> GetAllByUf(string uf);
        Task<City> GetByIbge(int ibge);
    }
}
