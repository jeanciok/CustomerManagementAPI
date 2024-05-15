using CustomerManagement.Core.Entities;

namespace CustomerManagement.Application.ViewModels
{
    public class LoginUserViewModel : BaseEntity
    {
        public LoginUserViewModel(Guid id, string name, string email, string token, Tenant tenant, Role role, string avatarUrl)
        {
            Id = id;
            Name = name;
            Email = email;
            Token = token;
            Tenant = tenant;
            Role = role;
            AvatarUrl = avatarUrl;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public Tenant Tenant { get; set; }
        public Role Role { get; set; }
        public string AvatarUrl { get; set; }
    }
}