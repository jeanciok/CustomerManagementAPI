using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class CustomerGroup : BaseEntity
    {
        public CustomerGroup() { }
        public CustomerGroup(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
