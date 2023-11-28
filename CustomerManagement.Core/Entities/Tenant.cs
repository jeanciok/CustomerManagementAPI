using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Tenant
    {
        public Tenant() { }
        public Tenant(Guid tenantId, string name, bool isActive, string slug)
        {
            TenantId = tenantId;
            Name = name;
            IsActive = true;
            Slug = slug;
        }

        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; }

        public ICollection<User> Users { get; set; }
        //public ICollection<Customer> Customers { get; set; }
        public ICollection<CustomerGroup> CustomerGroups { get; set; }
    }
}
