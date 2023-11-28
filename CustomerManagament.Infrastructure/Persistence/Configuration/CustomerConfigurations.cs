using CustomerManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.Persistence.Configuration
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(c => c.Tenant)
                .WithMany(t => t.Customers)
                .HasForeignKey(f => f.TenantId);

            builder
                .HasOne(c => c.City)
                .WithMany(x => x.Customers)
                .HasForeignKey(f => f.CityId);

            builder
                .HasOne(c => c.Group)
                .WithMany(g => g.Customers)
                .HasForeignKey(f => f.GroupId);
        }
    }
}
