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
    public class CostumerGroupConfigurations : IEntityTypeConfiguration<CustomerGroup>
    {
        public void Configure(EntityTypeBuilder<CustomerGroup> builder)
        {
            //builder
            //    .HasKey(p => p.Id);

            ////builder
            ////    .HasOne(u => u.Tenant)
            ////    .WithMany(t => t.CustomerGroups)
            ////    .HasForeignKey(f => f.TenantId);
        }
    }
}
