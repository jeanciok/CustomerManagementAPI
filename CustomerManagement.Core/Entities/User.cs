using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class User : BaseEntity
    {
        public User() { }
        public User(Guid id, string name, string email, string password, bool isActive, Guid tenantId, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            IsActive = isActive;
            TenantId = tenantId;
            Role = role;
        }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AvatarUrl { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiration { get; set; }

        [JsonIgnore]
        public ICollection<Receipt> Receipts { get; set; }
    }
}
