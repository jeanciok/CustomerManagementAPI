using CustomerManagement.Core.Entities;
using MediatR;
using System;

namespace CustomerManagement.Application.Commands.AddCustomer
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public CreateCustomerCommand(string name, string cnpj, string cpf, string rg, string phoneNumber, string phoneNumber2,
            string cep, string street, int number, string district, string additional, Guid groupId, string email, string description, Guid cityId)
        {
            Name = name;
            Cnpj = cnpj;
            Cpf = cpf;
            Rg = rg;
            PhoneNumber = phoneNumber;
            PhoneNumber2 = phoneNumber2;
            Cep = cep;
            Street = street;
            Number = number;
            District = district;
            Additional = additional;
            GroupId = groupId;
            Email = email;
            Description = description;
            CityId = cityId;
        }

        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string Additional { get; set; }
        public Guid GroupId { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Guid CityId { get; set; }
    }
}
