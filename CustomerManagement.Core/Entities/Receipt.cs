using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Receipt : BaseEntity
    {
        public Receipt(Guid customerId, decimal value, string description, DateTime date, Guid createdBy)
        {
            CustomerId = customerId;
            Value = value;
            Description = description;
            Date = date;
            CreatedBy = createdBy;
        }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public int Number { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid CreatedBy { get; set; }
        public User User { get; set; }
    }
}
