using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string token, Tenant tenant)
        {
            Email = email;
            Token = token;
            Tenant = tenant;
        }

        public string Email { get; set; }
        public string Token { get; set; }
        public Tenant Tenant { get; set; }
    }
}
