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
        public ReceiptViewModel(Guid id, int number, string tenantName, string customerName, decimal value, string description, DateTime date, string createdBy)
        {
            Id = id;
            Number = number;
            TenantName = tenantName;
            CustomerName = customerName;
            Value = value;
            Description = description;
            Date = date;
            CreatedBy = createdBy;
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public string TenantName { get; set; }
        public string CustomerName { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string CreatedBy { get; set; }
    }
}
