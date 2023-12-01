﻿using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagement.Core.Repositories;
using System.Linq;

namespace CustomerManagement.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task DeleteAsync(Guid id);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid id);
        Task UpdateAsync(Customer customer);
    }
}
