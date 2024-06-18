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
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(c => c.Customer)
                .WithMany(r => r.Receipts)
                .HasForeignKey(r => r.CustomerId);

            builder
                .HasOne(c => c.Tenant)
                .WithMany(r => r.Receipts)
                .HasForeignKey(r => r.TenantId);

            builder
                .HasOne(c => c.User)
                .WithMany(r => r.Receipts)
                .HasForeignKey(r => r.CreatedBy);
        }
    }
}
