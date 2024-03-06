using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class CustomerGroupViewModel
    {
        public CustomerGroupViewModel(Guid id, string name, ICollection<Customer> customers = null)
        {
            Id = id;
            Name = name;
            Customers = customers;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
