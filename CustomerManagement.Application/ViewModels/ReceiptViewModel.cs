using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class ReceiptViewModel
    {
        public ReceiptViewModel(Guid id, int number, Customer customer, Tenant tenant, decimal value, string description, DateTime date, User user)
        {
            Id = id;
            Number = number;
            Customer = customer;
            Tenant = tenant;
            Value = value;
            Description = description;
            Date = date;
            CreatedBy = user;
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public Customer Customer { get; set; }
        public Tenant Tenant { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public User CreatedBy { get; set; }
    }
}
