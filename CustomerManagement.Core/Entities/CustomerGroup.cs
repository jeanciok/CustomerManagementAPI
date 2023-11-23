using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class CustomerGroup : BaseEntity
    {
        public CustomerGroup(Tenant tenant, string name)
        {
            Tenant = tenant;
            Name = name;
        }

        public Tenant Tenant { get; set; }
        public string Name { get; set; }
    }
}
