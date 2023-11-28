using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class User : BaseEntity
    {
        public User() { }
        public User(Guid tenantId, Tenant tenant, string name, string email, string password, bool isActive)
        {
            TenantId = tenantId;
            Tenant = tenant;
            Name = name;
            Email = email;
            Password = password;
            IsActive = isActive;
        }

        public Guid TenantId { get; set; }

        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
