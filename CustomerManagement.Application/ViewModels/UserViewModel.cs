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
        public UserViewModel(Guid id, string name, string email, bool isActive, Tenant tenant, string avatarUrl)
        {
            Id = id;
            Name = name;
            Email = email;
            IsActive = isActive;
            Tenant = tenant;
            AvatarUrl = avatarUrl;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public Tenant Tenant { get; set; }
        public string AvatarUrl { get; set; }
    }
}
