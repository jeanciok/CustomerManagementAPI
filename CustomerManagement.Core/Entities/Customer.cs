using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(string name, DateTime birthDate, string phoneNumber, string businessPhone, string homePhone, string cnpj, string cpf, string rg, string cep, 
            string street, int number, string additional, CustomerGroup group, string email, string site, long description, string uRLPicture, City city, DateTime createdAt, 
            DateTime updatedAt, User userChange)
        {
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            BusinessPhone = businessPhone;
            HomePhone = homePhone;
            CNPJ = cnpj;
            CPF = cpf;
            RG = rg;
            CEP = cep;
            Street = street;
            Number = number;
            Additional = additional;
            Group = group;
            Email = email;
            Site = site;
            Description = description;
            URLPicture = uRLPicture;
            City = city;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            UserChange = userChange;
        }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessPhone { get; set; }
        public string HomePhone { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Additional { get; set; }
        public CustomerGroup Group { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public long Description { get; set; }
        public string URLPicture { get; set; }
        public City City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UserChange { get; set; }
    }
}
