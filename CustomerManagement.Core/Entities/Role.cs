using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Role : BaseEntity
    {
        public Role() { }
        public Role(string name, ICollection<User> users)
        {
            Name = name;
            Users = users;
        }

        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
