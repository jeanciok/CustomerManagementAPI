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
        public User(Guid id, string name, string email, string password, Guid roleId, bool isActive)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            RoleId = roleId;
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
