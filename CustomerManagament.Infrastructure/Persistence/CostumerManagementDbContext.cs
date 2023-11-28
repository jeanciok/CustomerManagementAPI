﻿using CustomerManagament.Infrastructure.Persistence.Configuration;
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

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttachmentConfigurations());
            modelBuilder.ApplyConfiguration(new CityConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerConfigurations());
            modelBuilder.ApplyConfiguration(new CostumerGroupConfigurations());
            modelBuilder.ApplyConfiguration(new RoleConfigurations());
            modelBuilder.ApplyConfiguration(new StateConfigurations());
            modelBuilder.ApplyConfiguration(new TenantConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
        }
    }
}
