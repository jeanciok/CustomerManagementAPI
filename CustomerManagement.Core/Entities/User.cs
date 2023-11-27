using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public Guid TenantId { get; set; }

        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
