using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(Guid id, string name, string phoneNumber, string phoneNumber2, string cNPJ, string cPF, string rG, string cEP, 
            string street, int number, string additional, string email, string description, Guid cityId, Guid groupId)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            PhoneNumber2 = phoneNumber2;
            CNPJ = cNPJ;
            CPF = cPF;
            RG = rG;
            CEP = cEP;
            Street = street;
            Number = number;
            Additional = additional;
            Email = email;
            Description = description;
            CityId = cityId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            GroupId = groupId;
        }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Additional { get; set; }
        public Guid GroupId { get; set; }
        public CustomerGroup Group { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Description { get; set; }
        public string URLPicture { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public ICollection<Attachment> Attachments { get; set; }
    }
}
