using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Role : BaseEntity
    {
        public Role(string name, ICollection<User> users)
        {
            Name = name;
            Users = users;
        }

        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
