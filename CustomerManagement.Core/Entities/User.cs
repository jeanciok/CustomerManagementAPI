using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class User : BaseEntity
    {
        public User(Tenant tenant, string name, Role role, string email, string password)
        {
            Tenant = tenant;
            Name = name;
            Role = role;
            Email = email;
            Password = password;
        }

        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
