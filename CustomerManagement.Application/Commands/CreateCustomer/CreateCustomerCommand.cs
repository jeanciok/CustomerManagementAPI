using CustomerManagement.Core.Entities;
using MediatR;
using System;

namespace CustomerManagement.Application.Commands.AddCustomer
{
    public class CreateCustomerCommand : IRequest<Unit>
    {
        public CreateCustomerCommand(Guid id, string name, DateTime birthDate, string phoneNumber, string businessPhone, string homePhone, string cNPJ, string cPF, string rG, 
            string cEP, string street, int number, string additional, Guid groupId, string email, string site, long description, string uRLPicture, Guid cityId)
        {
            Id = id;
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
            GroupId = groupId;
            Email = email;
            Site = site;
            Description = description;
            URLPicture = uRLPicture;
            CityId = cityId;
        }

        public Guid Id { get; set; }
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
        public Guid GroupId { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public long Description { get; set; }
        public string URLPicture { get; set; }
        public Guid CityId { get; set; }
    }
}
