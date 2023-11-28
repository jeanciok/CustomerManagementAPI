using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(Guid id, string name, string email, Role role, bool isActive)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            IsActive = isActive;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; }
    }
}
