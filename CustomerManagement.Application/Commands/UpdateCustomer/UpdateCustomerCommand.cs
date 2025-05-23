﻿using MediatR;
using System;

namespace CustomerManagement.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public UpdateCustomerCommand(Guid id, string name, string phoneNumber, string phoneNumber2, string cnpj, string cpf,
            string cEP, string street, string number, string district, string additional, Guid groupId, string email, string description, Guid cityId)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            PhoneNumber2 = phoneNumber2;
            CNPJ = cnpj;
            CPF = cpf;
            CEP = cEP;
            Street = street;
            Number = number;
            District = district;
            Additional = additional;
            GroupId = groupId;
            Email = email;
            Description = description;
            CityId = cityId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Additional { get; set; }
        public Guid GroupId { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Guid CityId { get; set; }
    }
}

