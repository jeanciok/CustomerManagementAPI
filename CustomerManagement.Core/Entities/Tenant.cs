using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Tenant
    {
        public Tenant() { }
        public Tenant(Guid tenantId, string name, bool isActive, string slug, string documentNumber)
        {
            TenantId = tenantId;
            Name = name;
            IsActive = isActive;
            Slug = slug;
            DocumentNumber = documentNumber;
        }

        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; }
        public string DocumentNumber { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; }
        [JsonIgnore]
        public ICollection<Customer> Customers { get; set; }
        [JsonIgnore]
        public ICollection<CustomerGroup> CustomerGroups { get; set; }
        [JsonIgnore]
        public ICollection<Receipt> Receipts { get; set; }
    }
}