using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Tenant
    {
        public Tenant(string name, string slug)
        {
            Name = name;
            Slug = slug;
            IsActive = true;
        }


        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; }
    }
}
