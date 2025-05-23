﻿using System;
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
        public Customer(Guid id, string name, string phoneNumber, string phoneNumber2, string cnpj, string cpf, string cep, 
            string street, string number, string district, string additional, string email, string description, Guid cityId, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            PhoneNumber2 = phoneNumber2;
            Cnpj = cnpj;
            Cpf = cpf;
            Cep = cep;
            Street = street;
            Number = number;
            District = district;
            Additional = additional;
            Email = email;
            Description = description;
            CityId = cityId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string? Additional { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? AvatarUrl { get; set; }
        [JsonIgnore]
        public ICollection<Attachment> Attachments { get; set; }
        [JsonIgnore]
        public ICollection<Receipt> Receipts { get; set; }
    }
}
