using CustomerManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.Persistence
{
    public class CostumerManagementDbContext : DbContext
    {
        public CostumerManagementDbContext(DbContextOptions<CostumerManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
    }
}
