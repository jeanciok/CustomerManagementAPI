using CustomerManagament.Infrastructure.Persistence.Configuration;
using CustomerManagement.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagament.Infrastructure.Persistence
{
    public class CustomerManagementDbContext : DbContext
    {
        public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfigurations());
            modelBuilder.ApplyConfiguration(new StateConfigurations());
            modelBuilder.ApplyConfiguration(new AttachmentConfigurations());
            modelBuilder.ApplyConfiguration(new TenantConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerConfigurations());
            //modelBuilder.ApplyConfiguration(new CostumerGroupConfigurations());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
        }
    }
}
