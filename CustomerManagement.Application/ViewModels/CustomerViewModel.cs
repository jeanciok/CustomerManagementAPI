using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerManagement.Application.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel(Guid id, string name, string phoneNumber, string phoneNumber2, string cpfCnpj, 
            string cEP, string street, string number, string district, string additional, string email, string description,
            City city, DateTime createdAt, DateTime updatedAt, string avatarUrl)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            PhoneNumber2 = phoneNumber2;
            CpfCnpj = cpfCnpj;
            CEP = cEP;
            Street = street;
            Number = number;
            District = district;
            Additional = additional;
            Email = email;
            Description = description;
            City = city;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            AvatarUrl = avatarUrl;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string CpfCnpj { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Additional { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AvatarUrl { get; set; }
    }
}
