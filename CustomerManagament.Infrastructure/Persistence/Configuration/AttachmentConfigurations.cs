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
    public class AttachmentConfigurations : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder
                .HasKey(p => p.Id);

            //builder
            //    .HasOne(c => c.Customer)
            //    .WithMany(a => a.Attachments)
            //    .HasForeignKey(a => a.CustomerId);
        }
    }
}
