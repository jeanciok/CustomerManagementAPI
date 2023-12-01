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
        public CustomerViewModel(Tenant tenant, string name, DateTime birthDate, string phoneNumber, string businessPhone, string homePhone, string cNPJ, string cPF, 
            string rG, string cEP, string street, int number, string additional, CustomerGroup group, string email, string site, long description, string uRLPicture, 
            City city, DateTime createdAt, DateTime updatedAt, ICollection<Attachment> attachments)
        {
            Tenant = tenant;
            Name = name;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            BusinessPhone = businessPhone;
            HomePhone = homePhone;
            CNPJ = cNPJ;
            CPF = cPF;
            RG = rG;
            CEP = cEP;
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
            Attachments = new List<Attachment>();
        }

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
        public ICollection<Attachment> Attachments { get; set; }
    }

}
